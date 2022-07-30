using static ActionRpg.Models.GameConstants;

namespace ActionRpg.Models.RaceModels
{
    public interface IRace
    {
        /// <summary>
        /// True: Race is fully configured and playable
        /// </summary>
        bool IsActive();
        /// <summary>
        /// Can be controlled by players
        /// </summary>
        bool IsPlayable();
        /// <summary>
        /// Max level cap
        /// </summary>
        int MaxLevel();
        /// <summary>
        /// Equation used to grow the character when it levels
        /// TODO : Pass in a character model, return a modified character model
        /// Alternatively, pass growth metrics back to calling method? TBD
        /// </summary>
        void StatGrowth();
        /// <summary>
        /// Gets race details
        /// </summary>
        Race GetRace();
        /// <summary>
        /// Defines whether or not the race can transcend their normal limits and be reborn
        /// TODO : Work out methods for ascension.
        /// </summary>
        bool CanTranscend();
    }
}
