using ActionRpg.Server.GameModels.Extensions.GeneratorExtensions;
using ActionRpg.Server.GameModels.GeneratorModels;
using ActionRpg.Server.GameModels.Helpers;
using ActionRpg.Server.GameModels.Interfaces;
using System.Reflection;
using static ActionRpg.Server.GameModels.GameConstants;

namespace ActionRpg.Server.GameServer.Generators
{
    public class CharacterGen
    {
        public CharacterGeneratorModel GenerateCharacter(Race race)
        {
            return new CharacterGeneratorModel(new CharacterGeneratorInputModel()
            {
                Race = GenerateRace(race),
            })
            { }.CreateFullCharacter();
        }

        public CharacterGeneratorModel GenerateCharacter(CharacterGeneratorInputModel? input = null)
        {
            if (input != null)
            {
                return new CharacterGeneratorModel(input);
            }

            return new CharacterGeneratorModel(new CharacterGeneratorInputModel() 
            {
                Race = GenerateRandomRace(),
            }) { }.CreateFullCharacter();
        }

        private IRace? GenerateRace(Race race)
        {
            var races = GeneralHelpers.GetAll<IRace>().ToArray();
            if (races.Length == 0)
            {
                return null;
            }
            
            return races.FirstOrDefault(x => x.GetRace().Equals(race));
        }

        private IRace? GenerateRandomRace()
        {
           var races = GeneralHelpers.GetAll<IRace>().ToArray();
           if(races.Length == 0)
            {
                return null;
            }
            return races[GeneralHelpers.GetRandBetweenTwoNumbers(0, races.Length - 1)];
        }
    }
}
