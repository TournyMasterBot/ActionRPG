using ActionRpg.Server.GameModels.Interfaces;
using static ActionRpg.Server.GameModels.GameConstants;

namespace ActionRpg.Server.GameModels.RaceModels
{
    public class HumanRace : IRace
    {
        public Race GetRace()
        {
            return Race.Human;
        }

        public bool IsActive()
        {
            return true;
        }

        public bool IsPlayable()
        {
            return true;
        }

        public int MaxLevel()
        {
            return 100;
        }

        public void StatGrowth()
        {
            throw new NotImplementedException();
        }

        public bool CanTranscend()
        {
            return true;
        }
    }
}
