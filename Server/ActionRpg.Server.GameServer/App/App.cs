using ActionRpg.Core.Helpers;
using ActionRpg.Models.AppModels;
using ActionRpg.Models.DatastoreModels;
using ActionRpg.Models.Interfaces;
using System.Diagnostics;
using static ActionRpg.Core.Constants;

namespace ActionRpg.Server.GameServer.App
{
    public class App : IApp
    {
        public AppInput Config { get; set; }
        public LoggingHelpers log { get; set; }
        public IDatastore Datastore { get; set; }

        public App(AppInput input)
        {
            try
            {
                var appInputSuccess = ValidateAppInput(input);
                if (!appInputSuccess)
                {
                    throw new ArgumentOutOfRangeException(nameof(input));
                }
                Config = input;
                log = new LoggingHelpers("App");
                if (!Directory.Exists(input.DatastoreBasePath))
                {
                    Directory.CreateDirectory(input.DatastoreBasePath);
                }
                Datastore = new SqliteDatastore(Path.GetFullPath($"{input.DatastoreBasePath}/{input.ProjectName}.{input.Stage}.db3"));
                Datastore.Init();
            }
            catch(Exception ex)
            {
                Debug.Print(ex.ToString());
                throw;
            }
        }

        private bool ValidateAppInput(AppInput input)
        {
            if (string.IsNullOrWhiteSpace(input.ProjectName))
            {
                throw new ArgumentNullException(nameof(input.ProjectName));
            }
            if (input.Stage == Stage.Unknown)
            {
                throw new ArgumentNullException(nameof(input.Stage));
            }
            return true;
        }

        public bool Init()
        {
            try
            {

                return true;
            }
            catch(Exception ex)
            {
                log.Error(ex, "App.Init");
                return false;
            }
        }
    }
}
