using ActionRpg.Client.GameClient.Managers;
using static ActionRpg.Models.GameConstants;

namespace ActionRpg.Core.TestGameClient
{
    /// <summary>
    /// Mock Game Client Tester. This client requires the Grpc server running.
    /// </summary>
    internal class Program
    {
        static async Task Main(string[] args)
        {
            GameManager.Initialize();

            Console.WriteLine("Calling Ping");
            var pingOutput = await StateManager.GrpcClient.PingServer();
            Console.WriteLine($"Ping Timestamp: {pingOutput.Timestamp}");
            Console.WriteLine("Calling Generate Human");
            var generateCharacterOutput = await StateManager.GrpcClient.GenerateCharacter("Jimmy", (int)Race.Human, (int)Profession.Warrior);
            Console.WriteLine($"Generate Character Result:\nMessage ID: {generateCharacterOutput.MessageId}, Timestamp: {generateCharacterOutput.Timestamp}, Response To MessageID: {generateCharacterOutput.ResponseToMessageId}\nData: {generateCharacterOutput.Data}");
            // This shouldn't return a dragon until it is marked as active - this is just a placeholder
            Console.WriteLine("Calling Generate Dragon");
            var generateCharacterOutput2 = await StateManager.GrpcClient.GenerateCharacter("Dergon", (int)Race.Dragon, (int)Profession.Mage);
            Console.WriteLine($"Generate Character Result2:\nMessage ID: {generateCharacterOutput2.MessageId}, Timestamp: {generateCharacterOutput2.Timestamp}, Response To MessageID: {generateCharacterOutput2.ResponseToMessageId}\nData: {generateCharacterOutput2.Data}");

        }
    }
}