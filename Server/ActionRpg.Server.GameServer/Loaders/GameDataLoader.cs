namespace ActionRpg.Server.GameServer.Loaders
{
    public class GameDataLoader
    {
        public static string[] LoadFileList(string gameDataBasePath)
        {
            if (!Directory.Exists(gameDataBasePath))
            {
                throw new DirectoryNotFoundException(nameof(gameDataBasePath));
            }
            return Directory.GetFiles(gameDataBasePath, "*.v0.json", SearchOption.AllDirectories);
        }

        public static Dictionary<string, string[]> LoadData(string[] fileList)
        {
            var returnData = new Dictionary<string, List<string>>();
            foreach(var filepath in fileList)
            {
                var data = LoadData(filepath);
                if (!returnData.ContainsKey(data.Item1))
                {
                    returnData.Add(data.Item1, new List<string>());
                }
                returnData[data.Item1].Add(data.Item2);
            }
            return returnData.ToDictionary(x => x.Key, x => x.Value.ToArray());
        }

        public static Tuple<string, string> LoadData(string filepath)
        {
            if (string.IsNullOrWhiteSpace(filepath))
            {
                throw new ArgumentNullException(nameof(filepath));
            }
            if (!File.Exists(filepath))
            {
                throw new FileNotFoundException(filepath);
            }

            var fileName = Path.GetFileNameWithoutExtension(filepath);
            if(fileName.IndexOf(".") == -1)
            {
                throw new ArgumentOutOfRangeException(nameof(filepath), $"{filepath} is not prefixed with item type");
            }

            var data = File.ReadAllText(filepath);
            if (data == null || data.Length == 0)
            {
                throw new ArgumentOutOfRangeException($"Defined item length of 0. Invalid file: {filepath}");
            }
            var key = fileName.Substring(0, fileName.IndexOf("."));
            return new Tuple<string, string>(key, data);
        }
    }
}
