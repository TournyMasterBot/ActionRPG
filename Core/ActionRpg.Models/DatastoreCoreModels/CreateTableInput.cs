namespace ActionRpg.Models.DatastoreCoreModels
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
