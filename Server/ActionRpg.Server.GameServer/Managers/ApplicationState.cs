using ActionRpg.Core;
using ActionRpg.Models.AppModels;
using ActionRpg.Server.GameServer.App;
using System;
using System.Reflection;

namespace ActionRpg.Server.GameServer.Managers
{
    public class ApplicationState
    {
        public static App.App App { get; set; }

        public static void Init(string env)
        {
            var stage = Constants.Stage.Unknown;
            switch (env.ToLower())
            {
                case "beta":
                {
                    stage = Constants.Stage.Beta;
                    break;
                }
                case "prod":
                {
                    stage = Constants.Stage.Prod;
                    break;
                }
                default:
                {
                    throw new ArgumentOutOfRangeException(nameof(env));
                }
            }
            // Todo : Allow override for base path to be user specified
            var appBasePath = Path.GetFullPath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty);
            var datastoreBasePath = Path.GetFullPath($"{appBasePath}/datastore");
            App = new App.App(new AppInput()
            {
                ProjectName = "ActionRpg.Server",
                Stage = stage,
                ApplicationBasePath = appBasePath,
                DatastoreBasePath = datastoreBasePath,
            });
        }
    }
}
