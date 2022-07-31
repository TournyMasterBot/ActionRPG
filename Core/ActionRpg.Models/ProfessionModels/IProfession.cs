using static ActionRpg.Models.GameConstants;

namespace ActionRpg.Models.ProfessionModels
{
    public interface IProfession
    {
        bool GetIsActive();
        bool GetIsPlayable();
        bool GetIsMultiClassAvailable();
        bool GetIsTranscendedProfession();
        int GetMaxLevel();
        void StatGrowth();
        Race[] GetSupportedRaces();
        bool IsRaceRestricted(Race race);
        Profession GetProfession();
    }
}
