namespace ActionRpg.Server.Models.ValidationModels
{
    public class CharacterValidation
    {
        public bool IsValid { get; set; }
        public Exception? Error { get; set; }
    }
}
