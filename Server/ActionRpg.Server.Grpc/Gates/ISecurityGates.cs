using ActionRpg.Server.Grpc.Gates;

namespace ActionRpg.Server.Grpc.SecurityGates
{
    public interface ISecurityGates
    {
        public PingSecurityGate Ping { get; set; }
        public ReportPlayerStatusSecurityGate ReportPlayerStatus { get; set; }
        public ReportZoneChangeSecurityGate ReportZoneChange { get; set; }
        public GenerateCharacterSecurityGate GenerateCharacter { get; set; }
    }
}
