namespace ActionRpg.Models.DatastoreCoreModels
{
    public class TableIndexInput
    {
        public string IndexName { get; set; }
        public ServerConstants.TableIndexType IndexType { get; set; }
        public TableFieldInput[] Fields { get; set; }
    }
}
