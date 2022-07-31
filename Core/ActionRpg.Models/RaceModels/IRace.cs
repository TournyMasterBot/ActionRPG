using static ActionRpg.Models.GameConstants;

namespace ActionRpg.Models.RaceModels
{
    public interface IRace
    {
        /// <summary>
        /// True: Race is fully configured and playable
        /// </summary>
        bool GetIsActive();
        /// <summary>
        /// Can be controlled by players
        /// </summary>
        bool GetIsPlayable();
        /// <summary>
        /// Max level cap
        /// </summary>
        int GetMaxLevel();
        /// <summary>
        /// Equation used to grow the character when it levels
        /// TODO : Pass in a character model, return a modified character model
        /// Alternatively, pass growth metrics back to calling method? TBD
        /// </summary>
        void GetStatGrowth();
        /// <summary>
        /// Gets race details
        /// </summary>
        Race GetRace();
        /// <summary>
        /// Defines whether or not the race can transcend their normal limits and be reborn
        /// TODO : Work out methods for ascension.
        /// </summary>
        bool GetCanTranscend();
        /// <summary>
        /// Defines whether or not the current race is a transcended race
        /// </summary>
        bool IsTranscendedRace();
    }
}
