using ActionRpg.Models.ProfessionModels;
using ActionRpg.Models.RaceModels;

namespace ActionRpg.Models.CharacterModels
{
    public interface ICharacter
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public IRace Race { get; set; }
        public IProfession Profession { get; set; }
    }
}
