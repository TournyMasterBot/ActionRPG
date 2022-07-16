using OmniBot.ActionRpg.Game.Requests;

namespace ActionRpg.Server.Grpc.Gates
{
    public class SendChatSecurityGate
    {
        public bool Checkpoint(SendChatInput request)
        {
            return true;
        }
    }
}
