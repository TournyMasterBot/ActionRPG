using Assets.Scripts.Grpc;

namespace Assets.Scripts.Managers
{
    public static class StateManager
    {
        public static ClientServerInterop GrpcClient;

        static StateManager()
        {
            GrpcClient = new ClientServerInterop(Constants.ServerHost, Constants.ServerPort);
        }

        public static void Initialize()
        {

        }
    }
}
