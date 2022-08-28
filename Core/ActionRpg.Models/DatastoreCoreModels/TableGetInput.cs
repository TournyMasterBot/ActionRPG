namespace ActionRpg.Models.DatastoreCoreModels
{
    public class TableGetInput
    {
        /// <summary>
        /// Table name to fetch from
        /// </summary>
        public string TableName { get; set; }
        /// <summary>
        /// Fetch key
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// Where clause of 'Must Exist'
        /// </summary>
        public Dictionary<string, dynamic> InclusiveFilters { get; set; }
        /// <summary>
        /// Where clause of 'Must Not Exist'
        /// </summary>
        public Dictionary<string, dynamic> ExclusiveFilters { get; set; }
    }
}
