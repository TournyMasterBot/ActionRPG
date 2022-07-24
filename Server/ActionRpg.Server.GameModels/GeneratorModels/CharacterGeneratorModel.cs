using ActionRpg.Server.GameModels.Interfaces;

namespace ActionRpg.Server.GameModels.GeneratorModels
{
    public class CharacterGeneratorModel : ICharacterGenerator
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public IRace Race { get; set; }

        
        public CharacterGeneratorModel(CharacterGeneratorInputModel input)
        {
            if(input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            if(input.ID == null)
            {
                ID = Core.Utils.CreateIdentifier();
            } 
            else
            {
                ID = input.ID;
            }

            if(input.Name == null) 
            {
                Name = Core.Utils.CreateName();
            } 
            else
            {
                Name = input.Name;
            }

            if(input.Race != null)
            {
                Race = input.Race;
            }
        }
    }
}
