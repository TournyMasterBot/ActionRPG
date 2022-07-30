using OmniBot.ActionRpg.Game.Requests;

namespace ActionRpg.Server.Grpc.Gates
{
    public class GenerateCharacterSecurityGate
    {
        public bool Checkpoint(GenerateCharacterInput request)
        {
            return true;
        }
    }
}
