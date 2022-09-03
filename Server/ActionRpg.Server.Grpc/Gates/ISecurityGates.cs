namespace ActionRpg.Server.Grpc.Gates
{
    public interface ISecurityGates
    {
        public PingSecurityGate Ping { get; set; }
        public ReportPlayerStatusSecurityGate ReportPlayerStatus { get; set; }
        public ReportZoneChangeSecurityGate ReportZoneChange { get; set; }
        public GenerateCharacterSecurityGate GenerateCharacter { get; set; }
        public GetItemSecurityGate GetItem { get; set; }
    }
}
