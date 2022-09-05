using ActionRpg.Core.Helpers;
using ActionRpg.Models.DatastoreCoreModels;
using ActionRpg.Models.Interfaces;
using Newtonsoft.Json;
using System.Collections.Concurrent;
using System.Data;
using System.Data.SQLite;
using System.Text;
using static ActionRpg.Models.ServerConstants;

namespace ActionRpg.Models.Datastore
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
                if(conn.State == ConnectionState.Open)
                {
                    return true;
                }
                conn.Open();
                return true;
            }
            catch(Exception ex)
            {
                log.Error(ex, "SqliteDatastore.OpenConnection");
                return false;
            }
        }

        public bool CloseConnection()
        {
            try
            {
                if(conn.State == ConnectionState.Closed)
                {
                    return true;
                }
                conn.Close();
                return true;
            }
            catch (Exception ex)
            {
                log.Error(ex, "SqliteDatastore.CloseConnection");
                return false;
            }
        }

        public IDataReader ExecuteSql(string sql)
        {
            throw new NotImplementedException();
        }

        public bool? CreateSimpleTable(string tableName)
        {
            if (string.IsNullOrWhiteSpace(tableName))
            {
                throw new ArgumentNullException(nameof(tableName));
            }
            try
            {
                using (var command = conn.CreateCommand())
                {
                    command.CommandText = $"create table if not exists {tableName} (key text primary key, data text) without rowid;";
                    command.ExecuteNonQuery();
                    return true;
                }
            }
            catch(Exception ex)
            {
                log.Error(ex, "CreateSimpleTable");
                return false;
            }
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

        public async Task<T?> GetFromDatastore<T>(TableGetInput input)
        {
            using (var command = conn.CreateCommand())
            {
                command.CommandText = $"select data from {input.TableName} where key = @key";
                command.Parameters.AddWithValue("@key", input.Key);
                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (reader.HasRows)
                    {
                        while (await reader.ReadAsync())
                        {
                            var item = JsonConvert.DeserializeObject<T>((string)reader[0]);
                            return item;
                        }
                    }
                    return default(T);
                }
            }
        }

        public async Task<T[]> GetListFromDatastore<T>(TableGetInput[] input)
        {
            var result = new List<T>();
            foreach(var request in input)
            {
                var data = await GetFromDatastore<T>(request);
                if(data != null)
                {
                    result.Add(data);
                }
            }
            return result.ToArray();
        }

        public async Task<T[]> ParallelGetListFromDatastore<T>(TableGetInput[] input, int maxParallel = 4)
        {
            var result = new ConcurrentBag<T>();
            var options = new ParallelOptions()
            {
                MaxDegreeOfParallelism = maxParallel
            };
            await Parallel.ForEachAsync(input, options, async (request, ct) =>
            {
                var data = await GetFromDatastore<T>(request);
                if (data != null)
                {
                    result.Add(data);
                }
            });
            return result.ToArray();
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

        public void Cleanup()
        {
            if(conn != null)
            {
                if(conn.State != ConnectionState.Closed)
                {
                    try
                    {
                        conn.Close();
                    }
                    catch(Exception ex)
                    {
                        log.Error(ex, "Cleanup.Close");
                    }
                }
                conn.Dispose();
            }
        }
    }
}
