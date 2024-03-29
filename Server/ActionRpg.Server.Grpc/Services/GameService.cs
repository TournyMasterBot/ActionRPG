using Microsoft.Extensions.Logging;
using OmniBot.ActionRpg.Game.Requests;

namespace ActionRpg.Server.Grpc.Services
{
    // This is the core game service class
    public partial class ActionRpgGameService : ActionRpgGame.ActionRpgGameBase
    {
        private Gates.SecurityGates gates { get; set; }
        private readonly ILogger<ActionRpgGame.ActionRpgGameBase> logger;
        public ActionRpgGameService(ILogger<ActionRpgGame.ActionRpgGameBase> _logger)
        {
            logger = _logger;
            gates = new Gates.SecurityGates();
        }
    }
}
