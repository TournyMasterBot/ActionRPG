using ActionRpg.Models.RaceModels;
using Newtonsoft.Json;

namespace ActionRpg.Models.CharacterModels
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public class Character : ICharacter
    {
        [JsonProperty(PropertyName = "id")]
        public string ID { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "race")]
        public IRace Race { get; set; }

        public Character()
        {

        }


        public Character(string id, string name, IRace race)
        {
            ID = id;
            Name = name;
            Race = race;
        }
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
}
