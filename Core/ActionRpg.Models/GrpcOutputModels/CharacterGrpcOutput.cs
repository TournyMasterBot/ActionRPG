using ActionRpg.Models.CharacterModels;
using Newtonsoft.Json;
using static ActionRpg.Models.GameConstants;

namespace ActionRpg.Models.GrpcOutputModels
{
    public class CharacterGrpcOutput
    {
        [JsonProperty(PropertyName = "id")]
        public string ID { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "race")]
        public Race Race { get; set; }

        public CharacterGrpcOutput(Character character)
        {
            ID = character.ID;
            Name = character.Name;
            Race = character.Race.GetRace();
        }
    }
}
