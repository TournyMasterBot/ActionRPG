using ActionRpg.Server.GameModels.Interfaces;

namespace ActionRpg.Server.GameModels.GeneratorModels
{
    public class CharacterGeneratorInputModel
    {
        public string? ID { get; set; }
        public string? Name { get; set; }
        public IRace? Race { get; set; }
    }
}
