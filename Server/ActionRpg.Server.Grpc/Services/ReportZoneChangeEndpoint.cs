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
        public override Task<ReportZoneChangeOutput> ReportZoneChange(ReportZoneChangeInput request, ServerCallContext context)
        {
            var now = DateTime.UtcNow;
            if (!Gates.SecurityGates.ReportZoneChange.Checkpoint(request))
            {
                Task.FromResult(new ReportZoneChangeOutput
                {
                    MessageId = Utils.CreateIdentifier(),
                    Timestamp = now.ToString(Constants.TimeFormat),
                    ResponseToMessageId = request.MessageId,
                    IsSuccess = false
                });
            }


            logger.LogDebug($"ReportZoneChange request received at {now.ToString(Constants.TimeFormat)} with a request of {Utils.ToJson(request)}");

            return Task.FromResult(new ReportZoneChangeOutput
            {
                MessageId = Utils.CreateIdentifier(),
                Timestamp = now.ToString(Constants.TimeFormat),
                ResponseToMessageId = request.MessageId,
                IsSuccess = true,
            });
        }
    }
}
