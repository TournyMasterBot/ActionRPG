using ActionRpg.Server.GameModels.Interfaces;

namespace ActionRpg.Server.GameModels.GeneratorModels
{
    public class CharacterGeneratorModel : ICharacterGenerator
    {
        public string ID { get; set; }
        public string Name { get; set; }
        
        public CharacterGeneratorModel()
        {

        }
    }
}
