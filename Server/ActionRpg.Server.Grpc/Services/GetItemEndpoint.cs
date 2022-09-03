using ActionRpg.Core;
using ActionRpg.Server.GameServer.Items;
using ActionRpg.Server.GameServer.Managers;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using OmniBot.ActionRpg.Game.Requests;
using System;
using System.Threading.Tasks;

namespace ActionRpg.Server.Grpc.Services
{
    public partial class ActionRpgGameService : ActionRpgGame.ActionRpgGameBase
    {
        private static ItemDatastore items = new ItemDatastore();

        /// <summary>
        /// Receives client side keep alive request
        /// </summary>
        /// <returns>Pong result</returns>
        public override async Task<GetItemResponse> GetItem(GetItemRequest request, ServerCallContext context)
        {
            var now = DateTime.UtcNow;
            if (!gates.GetItem.Checkpoint(request))
            {
                return await Task.FromResult(new GetItemResponse
                {
                    MessageId = Utils.CreateIdentifier(),
                    Timestamp = now.ToString(Constants.TimeFormat),
                    ResponseToMessageId = request.MessageId,
                    Payload = "{}" // Todo : Standardize on an error payload
                });
            }

            logger.LogDebug($"GetItem request received at {now.ToString(Constants.TimeFormat)} with a request of {Utils.ToJson(request)}");
            var item = await items.GetItem(request.ItemId);

            // If successful...
            return new GetItemResponse
            {
                MessageId = Utils.CreateIdentifier(),
                Timestamp = now.ToString(Constants.TimeFormat),
                ResponseToMessageId = request.MessageId,
                Payload = item?.ToJson()
            };
        }
    }
}
