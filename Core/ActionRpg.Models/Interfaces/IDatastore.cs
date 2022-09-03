using ActionRpg.Models.DatastoreCoreModels;
using System.Data;

namespace ActionRpg.Models.Interfaces
{
    public interface IDatastore
    {
        /// <summary>
        /// Name of the database
        /// </summary>
        public string DatabaseName { get; set; }
        /// <summary>
        /// Type of database, IE: sqlite, postgres, dynamodb, etc
        /// </summary>
        public ServerConstants.DatabaseType DatabaseType { get; set; }
        /// <summary>
        /// Init method for datastore to enable use
        /// </summary>
        public bool Init();
        /// <summary>
        /// Checks if database exists
        /// </summary>
        public bool DoesDatabaseExist();
        /// <summary>
        /// Creates specified database
        /// </summary>
        public bool CreateConnection();
        /// <summary>
        /// Checks if table exists in database
        /// </summary>
        public bool DoesTableExist(string tableName);
        /// <summary>
        /// Executes the specified sql statement and returns a handle to the reader
        /// </summary>
        public IDataReader ExecuteSql(string sql);
        /// <summary>
        /// Creates specified tables with fields and indexes
        /// </summary>
        public bool? CreateTable(CreateTableInput input);
        /// <summary>
        /// Saves object serialized to the datastore
        /// </summary>
        public bool SaveToDatastore<T>(SaveItemInput<T> input);
        /// <summary>
        /// Save a list of items serialized to the datastore
        /// </summary>
        public bool SaveListToDatastore<T>(SaveItemInput<T>[] input);
        /// <summary>
        /// Updates an item in the datastore
        /// </summary>
        public bool UpdateInDatastore<T>(UpdateItemInput<T> input);
        /// <summary>
        /// Updates a list of items in the datastore
        /// </summary>
        public bool UpdateListInDatastore<T>(UpdateItemInput<T>[] input);
        /// <summary>
        /// Gets an item from the datastore
        /// </summary>
        public T GetFromDatastore<T>(TableGetInput input);
        /// <summary>
        /// Gets a list of items from the datastore
        /// </summary>
        public T[] GetListFromDatastore<T>(TableGetInput[] input);
        /// <summary>
        /// Deletes an item from the datastore
        /// </summary>
        public bool DeleteFromDatastore(TableDeleteItemInput input);
        /// <summary>
        /// Deletes a list of items from the datastore
        /// </summary>
        public Tuple<string, bool> DeleteListFromDatastore(TableDeleteItemInput[] input);
        /// <summary>
        /// Imports raw data map content to seed the database
        /// Key: Table name
        /// Value: JSON payload for that table
        /// </summary>
        public bool? ImportDataToDatastore(Dictionary<string, string[]> dataMap);
    }
}
