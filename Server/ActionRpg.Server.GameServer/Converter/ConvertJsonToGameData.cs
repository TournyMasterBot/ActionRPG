using ActionRpg.Models.ItemModels;
using Newtonsoft.Json;

namespace ActionRpg.Server.GameServer.Converter
{
    public static class ConvertJsonToGameData
    {
        public static Item JsonToGameItem(this string json)
        {
            var item = JsonConvert.DeserializeObject<Item>(json);
            if(item == null)
            {
                throw new JsonException($"Failed to deserialize item. Malformed string: {json}");
            }
            return item;
        }
    }
}
