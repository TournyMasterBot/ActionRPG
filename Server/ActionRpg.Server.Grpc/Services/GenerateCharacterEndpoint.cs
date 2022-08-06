using ActionRpg.Core;
using ActionRpg.Models.CharacterModels;
using ActionRpg.Models.GrpcOutputModels;
using ActionRpg.Models.ValidationModels;
using ActionRpg.Server.GameServer.Helpers;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using OmniBot.ActionRpg.Game.Requests;
using System;
using System.Security;
using System.Threading.Tasks;

namespace ActionRpg.Server.Grpc.Services
{
    public partial class ActionRpgGameService : ActionRpgGame.ActionRpgGameBase
    {
        public override Task<GenerateCharacterOutput> GenerateCharacter(GenerateCharacterInput request, ServerCallContext context)
        {
            if (!gates.GenerateCharacter.Checkpoint(request))
            {
                return Task.FromResult(new GenerateCharacterOutput
                {
                    MessageId = Utils.CreateIdentifier(),
                    Timestamp = DateTime.UtcNow.ToString(Constants.TimeFormat),
                    ResponseToMessageId = request.MessageId,
                    Data = (new CharacterValidation()
                    {
                        IsValid = false,
                        Error = new SecurityException("Checkpoint failed")
                    }).ToJson()
                });
            }

            var character = CharacterHelpers.GenerateCharacter(new CreateCharacterInput()
            {
                Character = new Character()
                {
                    Name = request.Name,
                    Race = RaceHelpers.GetRaceFromInt(request.Race),
                    Profession = ProfessionHelpers.GetProfessionFromInt(request.Profession)
                }
            });
            var returnCharacter = new CharacterGrpcOutput(character);
            logger.LogDebug(returnCharacter.ToJson());
            return Task.FromResult(new GenerateCharacterOutput()
            {
                MessageId = Utils.CreateIdentifier(),
                Timestamp = DateTime.UtcNow.ToString(Constants.TimeFormat),
                ResponseToMessageId = request.MessageId,
                Data = returnCharacter.ToJson()
            });
        }
    }
}
