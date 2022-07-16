using OmniBot.ActionRpg.Game.Requests;

namespace ActionRpg.Server.Grpc.Gates
{
    public static class SecurityGates
    {
        public static PingSecurityGate Ping;
        public static SendChatSecurityGate SendChat;
        public static ReportPlayerStatusSecurityGate ReportPlayerStatus;
        public static ReportZoneChangeSecurityGate ReportZoneChange;
        static SecurityGates()
        {
            Ping = new PingSecurityGate();
            SendChat = new SendChatSecurityGate();
            ReportPlayerStatus = new ReportPlayerStatusSecurityGate();
            ReportZoneChange = new ReportZoneChangeSecurityGate();
        }
    }
}
