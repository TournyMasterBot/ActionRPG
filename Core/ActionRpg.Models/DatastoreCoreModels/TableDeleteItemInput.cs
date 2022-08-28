namespace ActionRpg.Models.DatastoreCoreModels
{
    public class TableDeleteItemInput
    {
        /// <summary>
        /// Table name to delete from
        /// </summary>
        public string TableName { get; set; }
        /// <summary>
        /// Filter key to delete
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// Excludes item from being deleted if filters apply
        /// </summary>
        public Dictionary<string, dynamic> Filters { get; set; }
    }
}
