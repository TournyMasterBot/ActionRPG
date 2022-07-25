using ActionRpg.Client.GameClient.Managers;

namespace ActionRpg.Core.TestGameClient
{
    /// <summary>
    /// Mock Game Client Tester. This client requires the Grpc server running.
    /// </summary>
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var output = await StateManager.GrpcClient.PingServer();
            Console.WriteLine($"Ping Timestamp: {output.Timestamp}");
        }
    }
}