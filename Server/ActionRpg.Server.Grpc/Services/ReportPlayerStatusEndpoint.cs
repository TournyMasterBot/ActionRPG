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
        /// <summary>
        /// Receives client update for stats like health, mana, stamina, position, and movement states
        /// </summary>
        /// <returns>Whether or not the request was accepted</returns>
        public override Task<ReportPlayerStatusOutput> ReportPlayerStatus(ReportPlayerStatusInput request, ServerCallContext context)
        {
            var now = DateTime.UtcNow;
            if (!gates.ReportPlayerStatus.Checkpoint(request))
            {
                Task.FromResult(new ReportPlayerStatusOutput
                {
                    MessageId = Utils.CreateIdentifier(),
                    Timestamp = now.ToString(Constants.TimeFormat),
                    ResponseToMessageId = request.MessageId,
                    Accepted = false
                });
            }


            logger.LogDebug($"ReportPlayerStatus request received at {now.ToString(Constants.TimeFormat)} with a request of {request.Timestamp}");

            return Task.FromResult(new ReportPlayerStatusOutput
            {
                MessageId = Utils.CreateIdentifier(),
                Timestamp = now.ToString(Constants.TimeFormat),
                ResponseToMessageId = request.MessageId,
                Accepted = true
            });
        }
    }
}
