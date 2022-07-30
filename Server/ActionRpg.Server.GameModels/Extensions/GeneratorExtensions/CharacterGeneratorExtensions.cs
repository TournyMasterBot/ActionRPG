using ActionRpg.Server.GameModels.CharacterModels;
using ActionRpg.Server.Models.ValidationModels;

namespace ActionRpg.Server.GameModels.Extensions.GeneratorExtensions
{
    public static class CharacterGeneratorExtensions
    {
        public static CharacterValidation ValidateCharacterGeneratorInputModel(this CreateCharacterInput input)
        {
            if(input == null)
            {
                return new CharacterValidation()
                {
                    IsValid = false,
                    Error = new ArgumentNullException(nameof(input))
                };
            }
            if(input.Character == null)
            {
                return new CharacterValidation()
                {
                    IsValid = false,
                    Error = new ArgumentNullException(nameof(input.Character))
                };
            }
            if(string.IsNullOrWhiteSpace(input.Character.ID))
            {
                return new CharacterValidation()
                {
                    IsValid = false,
                    Error = new ArgumentNullException(nameof(input.Character.ID))
                };
            }
            if (string.IsNullOrWhiteSpace(input.Character.Name))
            {
                return new CharacterValidation()
                {
                    IsValid = false,
                    Error = new ArgumentNullException(nameof(input.Character.Name))
                };
            }
            if(input.Character.Race == null)
            {
                return new CharacterValidation()
                {
                    IsValid = false,
                    Error = new ArgumentNullException(nameof(input.Character.Race))
                };
            }
            return new CharacterValidation()
            {
                IsValid = true,
                Error = null,
            };
        }
    }
}
