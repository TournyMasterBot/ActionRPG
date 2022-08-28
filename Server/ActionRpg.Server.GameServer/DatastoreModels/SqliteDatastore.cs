using ActionRpg.Core.Helpers;
using ActionRpg.Models.DatastoreCoreModels;
using ActionRpg.Models.Interfaces;
using System.Data.SQLite;
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
                if (!File.Exists($"{DatabaseName}"))
                {
                    var createDbSuccess = CreateDatabase();
                    if (!createDbSuccess)
                    {
                        return false;
                    }
                }
            }
            catch(Exception ex)
            {
                log.Error(ex, "SqliteDatastore.Init");
                return false;
            }
            return OpenConnection();
        }

        public bool CreateDatabase()
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

        public bool CreateTable(CreateTableInput input)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public T GetFromDatastore<T>(TableGetInput input)
        {
            throw new NotImplementedException();
        }

        public T[] GetListFromDatastore<T>(TableGetInput[] input)
        {
            throw new NotImplementedException();
        }

        public bool SaveListToDatastore<T>(SaveItemInput<T>[] input)
        {
            throw new NotImplementedException();
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
    }
}
