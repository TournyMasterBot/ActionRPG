using static ActionRpg.Models.GameConstants;

namespace ActionRpg.Models.RaceModels
{
    public class HumanRace : IRace
    {
        public Race GetRace()
        {
            return Race.Human;
        }

        public bool GetIsActive()
        {
            return true;
        }

        public bool GetIsPlayable()
        {
            return true;
        }

        public int GetMaxLevel()
        {
            return 100;
        }

        public void GetStatGrowth()
        {
            throw new NotImplementedException();
        }

        public bool GetCanTranscend()
        {
            return true;
        }

        public bool IsTranscendedRace()
        {
            return false;
        }
    }
}
