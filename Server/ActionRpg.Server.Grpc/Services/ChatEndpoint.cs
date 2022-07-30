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
        public override Task<SendChatOutput> SendChatMessage(SendChatInput request, ServerCallContext context)
        {
            var now = DateTime.UtcNow;
            if (!gates.SendChat.Checkpoint(request))
            {
                return Task.FromResult(new SendChatOutput()
                {
                    MessageId = Utils.CreateIdentifier(),
                    Timestamp = now.ToString(Constants.TimeFormat),
                    ResponseToMessageId = request.MessageId,
                    IsSuccess = false,
                    Message = "failed checks"
                });
            }

            logger.LogDebug($"SendChat request received at {now.ToString(Constants.TimeFormat)} with a request of {Utils.ToJson(request)}");
            return Task.FromResult(new SendChatOutput()
            {
                MessageId = Utils.CreateIdentifier(),
                Timestamp = now.ToString(Constants.TimeFormat),
                ResponseToMessageId = request.MessageId,
                IsSuccess = true,
                Message = "success"
            });
        }
    }
}
