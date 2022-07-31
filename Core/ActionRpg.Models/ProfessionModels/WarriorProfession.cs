using static ActionRpg.Models.GameConstants;

namespace ActionRpg.Models.ProfessionModels
{
    public class WarriorProfession : IProfession
    {
        public bool IsRaceRestricted(Race race)
        {
            if(GetSupportedRaces().Contains(race))
            {
                return false;
            }
            return true;
        }

        public bool GetIsActive()
        {
            return true;
        }

        public bool GetIsMultiClassAvailable()
        {
            return true;
        }

        public bool GetIsPlayable()
        {
            return true;
        }

        public bool GetIsTranscendedProfession()
        {
            return false;
        }

        public int GetMaxLevel()
        {
            return 100;
        }

        public Profession GetProfession()
        {
            return Profession.Warrior;
        }

        /// <summary>
        /// Get a list of supported races for this profession
        /// </summary>
        /// <returns>List of races that are valid for profession</returns>
        public Race[] GetSupportedRaces()
        {
            Race[] array = (Race[])Enum.GetValues(typeof(Race));
            return array.Where(x => x != Race.Unknown).ToArray();
        }

        public void StatGrowth()
        {
            throw new NotImplementedException();
        }
    }
}
