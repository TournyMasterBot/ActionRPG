namespace ActionRpg.Models
{
    public static class ServerConstants
    {
        public enum DatabaseType
        {
            Unknown = 0,
            Sqlite = 1,
            Postgres = 2,
            DynamoDb = 3,
            Disk = 4,
            S3 = 5,
        }

        public enum TableIndexType
        {
            Unknown = 0,
            Unique = 1,
            NonUnique = 2,
        };
    }
}
