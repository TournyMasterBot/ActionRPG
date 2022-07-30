using ActionRpg.Server.GameModels.Interfaces;

namespace ActionRpg.Server.GameModels.CharacterModels
{
    public interface ICharacter
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public IRace Race { get; set; }
    }
}
