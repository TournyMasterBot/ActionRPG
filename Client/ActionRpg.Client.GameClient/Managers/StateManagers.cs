using ActionRpg.Client.GameClient.Grpc;

namespace ActionRpg.Client.GameClient.Managers
{
    public static class StateManager
    {
        public static ClientServerInterop GrpcClient;

        static StateManager()
        {
            GrpcClient = new ClientServerInterop(GameClientConstants.ServerHost, GameClientConstants.ServerPort);
        }
    }
}
