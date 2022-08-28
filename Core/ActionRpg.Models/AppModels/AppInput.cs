using static ActionRpg.Core.Constants;

namespace ActionRpg.Models.AppModels
{
    public class AppInput
    {
        public string ProjectName { get; set; }
        public Stage Stage { get; set; }
        public string ApplicationBasePath { get; set; }
        public string DatastoreBasePath { get; set; }
    }
}
