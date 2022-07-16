using ActionRpg.Server.Grpc.Gates;
using OmniBot.ActionRpg.Game.Requests;

namespace ActionRpg.Server.Grpc.SecurityGates
{
    public interface ISecurityGates
    {
        public PingSecurityGate Ping(PingInput request);
        public ReportPlayerStatusSecurityGate ReportPlayerStatus(ReportPlayerStatusInput request);
        public ReportZoneChangeSecurityGate ReportZoneChange(ReportZoneChangeInput request);
    }
}
