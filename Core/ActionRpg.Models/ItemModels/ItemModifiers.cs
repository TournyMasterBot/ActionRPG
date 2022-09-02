using Newtonsoft.Json;

namespace ActionRpg.Models.ItemModels
{
    public class ItemModifiers
    {
        [JsonProperty(PropertyName = "health_absolute", NullValueHandling = NullValueHandling.Ignore)]
        public int HealthAbsolute { get; set; }
        [JsonProperty(PropertyName = "health_percent", NullValueHandling = NullValueHandling.Ignore)]
        public float HealthPercent { get; set; }
    }
}
