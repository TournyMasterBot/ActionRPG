namespace ActionRpg.Models.DatastoreCoreModels
{
    public class UpdateItemInput<T>
    {
        public string TableName { get; set; }
        public string Key { get; set; }
        public T Value { get; set; }
    }
}
