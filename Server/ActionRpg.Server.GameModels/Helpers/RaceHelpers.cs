using ActionRpg.Server.GameModels.Interfaces;
using static ActionRpg.Server.GameModels.GameConstants;

namespace ActionRpg.Server.GameModels.Helpers
{
    public static class RaceHelpers
    {
        public static IRace? GenerateRace(Race race)
        {
            var races = GeneralHelpers.GetAll<IRace>().ToArray();
            if (races.Length == 0)
            {
                return null;
            }

            return races.FirstOrDefault(x => x?.GetRace() == race);
        }

        public static IRace GenerateRandomRace()
        {
            var races = GeneralHelpers.GetAll<IRace>().ToArray();
            if (races == null || races.Length == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(races));
            }
            var race = races[GeneralHelpers.GetRandBetweenTwoNumbers(0, races.Length - 1)];
            if(race == null)
            {
                throw new ArgumentOutOfRangeException(nameof(race));
            }
            return race;
        }
    }
}
