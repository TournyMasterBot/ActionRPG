using ActionRpg.Core;
using ActionRpg.Server.Grpc.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OmniBot.ActionRpg.Game.Requests;
using System;
using System.Threading.Tasks;

namespace ActionRpgServer.Test.Grpc.Endpoints
{
    [TestClass]
    public class TestServicesPingEndpoint
    {
        private static string testMessageID = Utils.CreateIdentifier();
        private static ILogger<ActionRpgGameService> logger;
        private static ActionRpgGameService actionRpgGameServer;
        
        public TestServicesPingEndpoint()
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

        
        // Invalid Format
        [TestMethod]
        public async Task TestPingEndpointInvalidFormat()
        {
            var output = await actionRpgGameServer.Ping(new PingInput
            {
                MessageId = testMessageID,
                Timestamp = "Invalid format"
            }, null);
            Assert.IsNotNull(output);
            Assert.IsFalse(output.IsSuccess);
            Assert.AreEqual("failure", output.Status);
            Assert.AreEqual("format", output.Message);
            Assert.AreEqual(testMessageID, output.ResponseToMessageId);
        }

        // Invalid Latency
        [TestMethod]
        public async Task TestPingEndpointInvalidLatency()
        {
            var output = await actionRpgGameServer.Ping(new PingInput
            {
                MessageId = testMessageID,
                Timestamp = "2022-01-01 00:00:00.000"
            }, null);
            Assert.IsNotNull(output);
            Assert.IsFalse(output.IsSuccess);
            Assert.AreEqual("failure", output.Status);
            Assert.AreEqual("latency", output.Message);
            Assert.AreEqual(testMessageID, output.ResponseToMessageId);
        }

        // Future dated timestamp
        [TestMethod]
        public async Task TestPingEndpointFutureDatedTimestamp()
        {
            var now = DateTime.UtcNow.AddDays(1);
            var output = await actionRpgGameServer.Ping(new PingInput
            {
                MessageId = testMessageID,
                Timestamp = now.ToString(Constants.TimeFormat)
            }, null);
            Assert.IsNotNull(output);
            Assert.IsFalse(output.IsSuccess);
            Assert.AreEqual("failure", output.Status);
            Assert.AreEqual("invalid latency", output.Message);
            Assert.AreEqual(testMessageID, output.ResponseToMessageId);
        }

        // Success
        [TestMethod]
        public async Task TestPingEndpointSuccess()
        {
            var now = DateTime.UtcNow;
            var output = await actionRpgGameServer.Ping(new PingInput
            {
                MessageId = testMessageID,
                Timestamp = now.ToString(Constants.TimeFormat)
            }, null);
            Assert.IsNotNull(output);
            Assert.IsTrue(output.IsSuccess);
            Assert.AreEqual("success", output.Status);
            Assert.AreEqual("success", output.Message);
            Assert.AreEqual(testMessageID, output.ResponseToMessageId);
        }
    }
}
