using ActionRpg.Server.GameModels.CharacterModels;

namespace ActionRpg.Server.GameModels.Interfaces
{
    public interface ICharacterGenerator
    {
        public ICharacter Character { get; set; }
        public IRace Race { get; set; }
    }
}
