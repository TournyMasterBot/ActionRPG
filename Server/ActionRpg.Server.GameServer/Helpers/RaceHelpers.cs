using ActionRpg.Models.RaceModels;
using static ActionRpg.Models.GameConstants;

namespace ActionRpg.Server.GameServer.Helpers
{
    public static class RaceHelpers
    {
        public static IRace? GetRaceFromInt(int raceSelection)
        {
            if (raceSelection > Enum.GetValues(typeof(Race)).Length)
            {
                return null;
            }
            var race = (Race)raceSelection;
            return GenerateRace(race);
        }

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
            if (race == null)
            {
                throw new ArgumentOutOfRangeException(nameof(race));
            }
            return race;
        }

        public static Race[] GetAllRaces()
        {
            return GeneralHelpers.GetEnumItems<Race>().Where(x => x != Race.Unknown).ToArray();
        }
    }
}
