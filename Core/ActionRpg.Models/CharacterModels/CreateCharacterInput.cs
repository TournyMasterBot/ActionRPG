using ActionRpg.Models.ProfessionModels;
using ActionRpg.Models.RaceModels;

namespace ActionRpg.Models.CharacterModels
{
    public class CreateCharacterInput
    {
        public ICharacter Character { get; set; }

        public CreateCharacterInput()
        {
            Character = new Character();
        }

        public CreateCharacterInput(string id, string name, IRace race, IProfession profession)
        {
            Character = new Character()
            {
                ID = id,
                Name = name,
                Race = race,
                Profession = profession
            };
        }
    }
}
