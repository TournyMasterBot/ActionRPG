using ActionRpg.Server.Grpc.SecurityGates;

namespace ActionRpg.Server.Grpc.Gates
{
    public class SecurityGates : ISecurityGates
    {
        public PingSecurityGate Ping { get; set; }
        public SendChatSecurityGate SendChat { get; set; }
        public ReportPlayerStatusSecurityGate ReportPlayerStatus { get; set; }
        public ReportZoneChangeSecurityGate ReportZoneChange { get; set; }
        public GenerateCharacterSecurityGate GenerateCharacter { get; set; }
        
        public SecurityGates()
        {
            Ping = new PingSecurityGate();
            SendChat = new SendChatSecurityGate();
            ReportPlayerStatus = new ReportPlayerStatusSecurityGate();
            ReportZoneChange = new ReportZoneChangeSecurityGate();
            GenerateCharacter = new GenerateCharacterSecurityGate();
        }
    }
}
