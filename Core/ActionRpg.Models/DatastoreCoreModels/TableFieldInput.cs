namespace ActionRpg.Models.DatastoreCoreModels
{
    public class TableFieldInput
    {
        public string FieldName { get; set; }
        public long? MaxLength { get; set; }
        public string FieldType { get; set; }
        public bool IsPrimaryKey { get; set; }
        public bool IsNullable { get; set; }
    }
}
