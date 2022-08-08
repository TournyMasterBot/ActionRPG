using ActionRpg.Core;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using OmniBot.ActionRpg.Game.Requests;
using System;
using System.Threading.Tasks;

namespace ActionRpg.Server.Grpc.Services
{
    public partial class ActionRpgGameService : ActionRpgGame.ActionRpgGameBase
    {
        private static readonly double maxLatency = TimeSpan.FromMilliseconds(250).TotalMilliseconds;

        /// <summary>
        /// Receives client side keep alive request
        /// </summary>
        /// <returns>Pong result</returns>
        public override Task<PingOutput> Ping(PingInput request, ServerCallContext context)
        {
            var now = DateTime.UtcNow;
            if (!gates.Ping.Checkpoint(request))
            {
                return Task.FromResult(new PingOutput
                {
                    MessageId = Utils.CreateIdentifier(),
                    Timestamp = now.ToString(Constants.TimeFormat),
                    ResponseToMessageId = request.MessageId,
                    IsSuccess = false,
                    Status = "failure",
                    Message = "request",
                });
            }

            logger.LogDebug($"Ping request received at {now.ToString(Constants.TimeFormat)} with a request of {Utils.ToJson(request)}");

            // If ping format is malformed...
            var pingFormatSuccess = DateTime.TryParse(request.Timestamp, out DateTime pingTime);
            if (!pingFormatSuccess)
            {
                return Task.FromResult(new PingOutput
                {
                    MessageId = Utils.CreateIdentifier(),
                    Timestamp = now.ToString(Constants.TimeFormat),
                    ResponseToMessageId = request.MessageId,
                    IsSuccess = false,
                    Status = "failure",
                    Message = "format",
                });
            }

            var timeDiff = now.Subtract(pingTime).TotalMilliseconds;
            logger.LogDebug($"Ping Request Time Difference: {timeDiff}");

            // If latency is too high...
            if (timeDiff > maxLatency)
            {
                return Task.FromResult(new PingOutput
                {
                    MessageId = Utils.CreateIdentifier(),
                    Timestamp = now.ToString(Constants.TimeFormat),
                    ResponseToMessageId = request.MessageId,
                    IsSuccess = false,
                    Status = "failure",
                    Message = "latency",
                });
            }

            // If impossible timestamp...
            if (timeDiff < 0)
            {
                return Task.FromResult(new PingOutput
                {
                    MessageId = Utils.CreateIdentifier(),
                    Timestamp = now.ToString(Constants.TimeFormat),
                    ResponseToMessageId = request.MessageId,
                    IsSuccess = false,
                    Status = "failure",
                    Message = "invalid latency",
                });
            }

            // If successful...
            return Task.FromResult(new PingOutput
            {
                MessageId = Utils.CreateIdentifier(),
                Timestamp = now.ToString(Constants.TimeFormat),
                ResponseToMessageId = request.MessageId,
                IsSuccess = true,
                Status = "success",
                Message = "success",
            });
        }
    }
}
