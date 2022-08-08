using ActionRpg.Core;
using ActionRpg.Models.CharacterModels;

namespace ActionRpg.Server.GameServer.Helpers
{
    public static class CharacterHelpers
    {
        public static Character GenerateCharacter(CreateCharacterInput input)
        {
            Character character;
            if (input == null)
            {
                character = new Character();
            }
            else
            {
                character = new Character()
                {
                    ID = input.Character.ID ?? Utils.CreateIdentifier(),
                    Name = input.Character.Name ?? Utils.CreateName(),
                    Race = input.Character.Race ?? RaceHelpers.GenerateRandomRace(),
                    Profession = input.Character.Profession ?? ProfessionHelpers.GenerateRandomProfession(),
                };
            }

            return character;
        }
    }
}
