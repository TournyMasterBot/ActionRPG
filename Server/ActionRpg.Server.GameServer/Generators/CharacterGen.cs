using ActionRpg.Models.CharacterModels;
using ActionRpg.Server.GameServer.Helpers;
using static ActionRpg.Models.GameConstants;

namespace ActionRpg.Server.GameServer.Generators
{
    public class CharacterGen
    {
        public Character GenerateCharacter()
        {
            return CharacterHelpers.GenerateCharacter(new CreateCharacterInput() { });
        }

        public Character GenerateCharacter(Race _race)
        {
            var race = RaceHelpers.GenerateRace(_race);
            if (race == null)
            {
                throw new NullReferenceException(nameof(race));
            }
            return CharacterHelpers.GenerateCharacter(new CreateCharacterInput()
            {
                Character = new Character()
                {
                    Race = race,
                }
            });
        }

        public Character GenerateCharacter(CreateCharacterInput input)
        {
            return CharacterHelpers.GenerateCharacter(input);
        }
    }
}
