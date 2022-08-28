using ActionRpg.Models.DatastoreCoreModels;

namespace ActionRpg.Server.GameServer.DatastoreModels
{
    public class CreateTableInput
    {
        public string TableName { get; set; }
        /// <summary>
        /// Field Name, Field Type
        /// </summary>
        public TableFieldInput[] Fields { get; set; }
        public TableIndexInput[] TableIndexes { get; set; }
    }
}
