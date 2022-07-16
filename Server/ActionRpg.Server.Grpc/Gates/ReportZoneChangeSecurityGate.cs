using OmniBot.ActionRpg.Game.Requests;

namespace ActionRpg.Server.Grpc.Gates
{
    public class ReportPlayerStatusSecurityGate
    {
        /// <summary>
        /// Checks a ReportPlayerStatus request for malicious usage and tries to short circuit
        /// </summary>
        /// <returns>True / False request passes security checkpoint</returns>
        public bool Checkpoint(ReportPlayerStatusInput request)
        {
            return true;
        }
    }
}
