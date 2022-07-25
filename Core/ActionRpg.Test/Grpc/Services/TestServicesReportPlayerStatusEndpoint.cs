using ActionRpg.Server.Grpc.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OmniBot.ActionRpg.Game.Requests;
using System;
using System.Threading.Tasks;

namespace ActionRpg.Core.Test.Grpc.Services
{
    [TestClass]
    public class TestServicesReportPlayerStatusEndpoint
    {
        private static string testMessageID = Utils.CreateIdentifier();
        private static ILogger<ActionRpgGameService> logger;
        private static ActionRpgGameService actionRpgGameServer;
        public TestServicesReportPlayerStatusEndpoint()
        {
            // Initialize Logger
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .BuildServiceProvider();
            var factory = serviceProvider.GetService<ILoggerFactory>();
            logger = factory.CreateLogger<ActionRpgGameService>();

            // Initialize Service
            actionRpgGameServer = new ActionRpgGameService(logger);
        }

        [TestMethod]
        public async Task TestReportPlayerStatusSuccess()
        {
            var now = DateTime.UtcNow;
            var endTime = now.AddSeconds(3);
            var output = await actionRpgGameServer.ReportPlayerStatus(new ReportPlayerStatusInput()
            {
                MessageId = testMessageID,
                Timestamp = now.ToString(Constants.TimeFormat),
                Health = 100,
                Mana = 100,
                Stamina = 100,
                Zone = "Scene1",
                Region = "Level1",
                Local = "Water Cooler",
                PosX = 0.0f,
                PosY = 0.0f,
                PosZ = 0.0f,
                IsMoving = false,
                IsGrounded = true,
                IsAiming = false,
                IsAttacking = false,
                Animation = "Idle",
                AnimationStartTime = now.ToString(Constants.TimeFormat),
                AnimationEndTime = endTime.ToString(Constants.TimeFormat),
            }, null);
            Assert.IsNotNull(output);
            Assert.IsTrue(output.Accepted);
        }
    }
}
