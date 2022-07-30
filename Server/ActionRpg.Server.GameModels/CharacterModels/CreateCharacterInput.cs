using ActionRpg.Server.GameModels.Interfaces;

namespace ActionRpg.Server.GameModels.CharacterModels
{
    public class CreateCharacterInput
    {
        public ICharacter Character { get; set; }

        public CreateCharacterInput()
        {
            Character = new Character();
        }

        public CreateCharacterInput(string id, string name, IRace race)
        {
            Character = new Character()
            {
                ID = id,
                Name = name,
                Race = race
            };
        }
    }
}
