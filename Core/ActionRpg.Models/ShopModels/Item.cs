using Newtonsoft.Json;

namespace ActionRpg.Models.ShopModels
{
    public class Item
    {
        [JsonProperty(PropertyName = "id")]
        public string ItemID { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string ItemName { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string ItemDescription { get; set; }
    }
}
