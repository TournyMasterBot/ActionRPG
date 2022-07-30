using ActionRpg.Core;
using Grpc.Core;
using OmniBot.ActionRpg.Game.Requests;

namespace ActionRpg.Client.GameClient.Grpc
{
    public class ClientServerInterop
    {
        private object lockObj = new object();
        private string? server { get; set; }
        private ActionRpgGame.ActionRpgGameClient client { get; set; }
        private Channel? channel { get; set; }


        public ClientServerInterop(string host, string port)
        {
            lock (lockObj)
            {
                if (client != null)
                {
                    return;
                }
                try
                {
                    server = $"{host}:{port}";
                    channel = new Channel(server, ChannelCredentials.Insecure); // Todo : Use credentials
                    client = new ActionRpgGame.ActionRpgGameClient(channel);
                }
                finally { }
            }
        }
        public async Task<PingOutput> PingServer()
        {
            var output = await client.PingAsync(new PingInput()
            {
                Timestamp = DateTime.UtcNow.ToString(Constants.TimeFormat),
            });
            return output;
        }

        public async Task<ReportZoneChangeOutput> ReportZoneChangeToServer(string zone)
        {
            var output = await client.ReportZoneChangeAsync(new ReportZoneChangeInput()
            {
                MessageId = Utils.CreateIdentifier(),
                Timestamp = DateTime.UtcNow.ToString(Constants.TimeFormat),
                ZoneName = zone,
            });
            return output;
        }

        public async Task<GenerateCharacterOutput> GenerateCharacter(string name, int race)
        {
            {
                var output = await client.GenerateCharacterAsync(new GenerateCharacterInput()
                {
                    MessageId = Utils.CreateIdentifier(),
                    Timestamp = DateTime.UtcNow.ToString(Constants.TimeFormat),
                    Name = name,
                    Race = race
                });
                return output;
            };
        }

        public void Shutdown()
        {
            if (channel != null)
            {
                channel.ShutdownAsync().Wait();
            }
        }
    }
}
