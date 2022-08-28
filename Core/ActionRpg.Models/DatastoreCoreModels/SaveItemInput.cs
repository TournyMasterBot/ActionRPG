namespace ActionRpg.Models.DatastoreCoreModels
{
    public class SaveItemInput<T>
    {
        public string TableName { get; set; }
        public string Key { get; set; }
        public T Value { get; set; }
    }
}
