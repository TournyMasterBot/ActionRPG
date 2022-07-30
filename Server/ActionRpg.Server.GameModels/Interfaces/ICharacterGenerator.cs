using ActionRpg.Models.CharacterModels;
using ActionRpg.Models.RaceModels;

namespace ActionRpg.Server.GameModels.Interfaces
{
    public interface ICharacterGenerator
    {
        public ICharacter Character { get; set; }
        public IRace Race { get; set; }
    }
}
