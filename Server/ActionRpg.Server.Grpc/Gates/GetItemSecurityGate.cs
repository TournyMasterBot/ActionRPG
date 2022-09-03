using OmniBot.ActionRpg.Game.Requests;

namespace ActionRpg.Server.Grpc.Gates
{
    public class PingSecurityGate
    {
        /// <summary>
        /// Checks a Ping request for malicious usage and tries to short circuit
        /// </summary>
        /// <returns>True / False request passes security checkpoint</returns>
        public bool Checkpoint(PingInput request)
        {
            return true;
        }
    }
}
