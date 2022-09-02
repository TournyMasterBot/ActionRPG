using Newtonsoft.Json;
using static ActionRpg.Models.GameConstants;

namespace ActionRpg.Models.ItemModels
{
    public class Item
    {
        /// <summary>
        /// GUID of object. Arbitrary.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string ItemID { get; set; }
        /// <summary>
        /// Version ID, this tracks iterations of the same item. 
        /// Item source will always pull from version `0` 
        /// but this version identifier helps track changes for caching purposes
        /// </summary>
        [JsonProperty(PropertyName = "version")]
        public string Version { get; set; }
        /// <summary>
        /// Type of data being loaded
        /// </summary>
        [JsonProperty(PropertyName = "load_data_type")]
        public LoadDataType LoadedDataType { get; set; }
        /// <summary>
        /// Date of initial item creation
        /// </summary>
        [JsonProperty(PropertyName = "created_at")]
        public DateTime CreatedAt { get; set; }
        /// <summary>
        /// Date of most recent change to item
        /// </summary>
        [JsonProperty(PropertyName = "updated_at")]
        public DateTime UpdatedAt { get; set; }
        /// <summary>
        /// Item name that should be displayed to players
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string ItemName { get; set; }
        /// <summary>
        /// Model name that needs to be loaded to display item in world
        /// </summary>
        [JsonProperty(PropertyName = "model_name")]
        public string ModelName { get; set; }
        /// <summary>
        /// Item description shown to players
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string ItemDescription { get; set; }
        /// <summary>
        /// Defines whether or not the player can consume the item
        /// and what type of consumable the item is.
        /// '0' means the item is not consumable.
        /// </summary>
        [JsonProperty(PropertyName = "consumable_type")]
        public bool ConsumableType { get; set; }
        /// <summary>
        /// Defines whether or not the player can equip the item, 
        /// and what item slot the item is equipped to.
        /// '0' means the item is not equipable.
        /// </summary>
        [JsonProperty(PropertyName = "equip_location")]
        public bool EquipLocation { get; set; }
        /// <summary>
        /// Defines what item modifiers are applied when the item is used
        /// </summary>
        
        [JsonProperty(PropertyName = "modifiers")]
        public ItemModifiers[] ItemModifiers { get; set; }
    }
}
