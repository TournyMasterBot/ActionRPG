using ActionRpg.Core.Helpers;
using ActionRpg.Models.DatastoreCoreModels;
using ActionRpg.Models.Interfaces;
using Newtonsoft.Json;
using System.Data;
using System.Data.SQLite;
using System.Text;
using static ActionRpg.Models.ServerConstants;

namespace ActionRpg.Models.DatastoreModels
{
    public class SqliteDatastore : IDatastore
    {
        public string DatabaseName { get; set; }
        public DatabaseType DatabaseType { get; set; }
        public LoggingHelpers log { get; set; }
        private static SQLiteConnection conn;

        public SqliteDatastore(string databaseName)
        {
            if (string.IsNullOrWhiteSpace(databaseName))
            {
                throw new ArgumentNullException(nameof(databaseName));
            }
            log = new LoggingHelpers("Datastore");
            DatabaseName = databaseName;
            DatabaseType = DatabaseType.Sqlite;
        }

        public bool Init()
        {
            try
            {
                var dbConnectSuccess = CreateConnection();
                if (!dbConnectSuccess)
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                log.Error(ex, "SqliteDatastore.Init");
                return false;
            }
            return OpenConnection();
        }

        public bool CreateConnection()
        {
            try
            {
                var createName = $"{DatabaseName}";
                conn = new SQLiteConnection($"DataSource={createName};Version=3;");
                return true;
            }
            catch (Exception ex)
            {
                log.Error(ex, "SqliteDatastore.CreateDatabase");
                return false;
            }            
        }

        public bool OpenConnection()
        {
            try
            {
                conn.Open();
                return true;
            }
            catch(Exception ex)
            {
                log.Error(ex, "SqliteDatastore.OpenConnection");
                return false;
            }
        }

        public IDataReader ExecuteSql(string sql)
        {
            throw new NotImplementedException();
        }

        public bool? CreateTable(CreateTableInput input)
        {
            if(input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            if(input.Fields.Length == 0)
            {
                throw new ArgumentNullException(nameof(input.Fields));
            }
            try
            {
                var fieldBuilder = new StringBuilder();
                foreach(var field in input.Fields)
                {
                    var primaryKey = field.IsPrimaryKey ? "PRIMARY KEY" : "";
                    var isNullable = field.IsNullable || field.IsPrimaryKey ? "" : "NOT NULL";
                    fieldBuilder.AppendLine($",{field.FieldName} {fieldTypeSelector(field.FieldType)} {primaryKey}{isNullable}");
                }
                var queryBuilder = new StringBuilder();
                queryBuilder.AppendLine($"create table if not exists {input.TableName} (");
                queryBuilder.AppendLine($"{fieldBuilder.ToString().Substring(1)}");
                queryBuilder.AppendLine(") without rowid;");
                using (var command = conn.CreateCommand())
                {
                    command.CommandText = queryBuilder.ToString();
                    command.ExecuteNonQuery();
                    foreach(var index in input.TableIndexes)
                    {
                        var indexType = index.IndexType == TableIndexType.Unique ? "UNIQUE" : "";
                        command.CommandText = $"create {indexType} index if not exists {index.IndexName} on {input.TableName}({string.Join(",", index.Fields)});";
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception ex)
            {
                log.Error(ex, "CreateTable");
                return false;
            }
            return true;
        }

        private string fieldTypeSelector(string type)
        {
            switch (type)
            {
                case "string":
                {
                    return "TEXT";
                }
                case "text":
                {
                    return "TEXT";
                }
                case "blob":
                {
                    return "BLOB";
                }
                default:
                {
                    throw new NotImplementedException($"Unknown field type: {type}");
                }
            }
        }

        public bool DeleteFromDatastore(TableDeleteItemInput input)
        {
            throw new NotImplementedException();
        }

        public Tuple<string, bool> DeleteListFromDatastore(TableDeleteItemInput[] input)
        {
            throw new NotImplementedException();
        }

        public bool DoesDatabaseExist()
        {
            throw new NotImplementedException();
        }

        public bool DoesTableExist(string tableName)
        {
            using (var command = conn.CreateCommand())
            {
                command.CommandText = "SELECT count(*) as cnt FROM sqlite_master WHERE type='table' AND name=@tableName;";
                command.Parameters.AddWithValue("@tableName", tableName);
                return (long)command.ExecuteScalar() > 0;
            }
        }

        public T GetFromDatastore<T>(TableGetInput input)
        {
            throw new NotImplementedException();
        }

        public T[] GetListFromDatastore<T>(TableGetInput[] input)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// First pass hack job to save list to datastore. 
        /// This is a non optimized single item insert script.
        /// Enhancements should use bulk queries
        /// </summary>
        /// <returns>True: Successfully executed without exceptions, False: Exception was encountered during execution</returns>
        public bool SaveListToDatastore<T>(SaveItemInput<T>[] input)
        {
            var success = true;
            using(var command = conn.CreateCommand())
            {
                foreach(var item in input)
                {
                    try
                    {
                        command.CommandText = @$"
                            update {item.TableName} set data = @data where key = @key;
                            insert into {item.TableName} (key, data) 
                            select @key, @data 
                            where not exists (
                                select 1 from {item.TableName} 
                                where key = @key
                            );";
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@key", item.Key);
                        command.Parameters.AddWithValue("@data", JsonConvert.SerializeObject(item.Value));
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        log.Error(ex, "SaveListToDatastore");
                        success = false;
                    }
                }
            }
            return success;
        }

        public bool SaveToDatastore<T>(SaveItemInput<T> input)
        {
            throw new NotImplementedException();
        }

        public bool UpdateInDatastore<T>(UpdateItemInput<T> input)
        {
            throw new NotImplementedException();
        }

        public bool UpdateListInDatastore<T>(UpdateItemInput<T>[] input)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Imports raw data map content to seed the database
        /// Key: Table name
        /// Value: JSON payload for that table
        /// </summary>
        /// <param name="dataMap"></param>
        /// <returns>Null: Data load not attempted. True: Data load success, False: Data load failure</returns>
        public bool? ImportDataToDatastore(Dictionary<string, string[]> dataMap)
        {
            if(dataMap == null || dataMap.Count == 0)
            {
                return null;
            }
            foreach(var table in dataMap)
            {
                if (!DoesTableExist(table.Key))
                {
                    throw new NotImplementedException($"Error - table does not exist: {table.Key}");
                }
                foreach(var row in table.Value)
                {
                    using (var command = conn.CreateCommand())
                    {
                        command.CommandText = $"select json_insert({row})";
                    }
                }                
            }
            return true;
        }
    }
}
