using ActionRpg.Core.Helpers;
using ActionRpg.Models.DatastoreCoreModels;
using ActionRpg.Models.Interfaces;
using ActionRpg.Models.ItemModels;
using ActionRpg.Server.GameServer.Converter;
using ActionRpg.Server.GameServer.Loaders;
using ActionRpg.Server.GameServer.Managers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ActionRpg.Server.Grpc
{
    public class Program
    {
        private static LoggingHelpers log { get; set; }

        public static void Main(string[] args)
        {
            try
            {
                AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionHandler;
                ApplicationState.Init("beta"); // Todo : Support args to switch beta/prod
                log = new LoggingHelpers("Program");
                var gameDataFiles = GameDataLoader.LoadFileList(Path.GetFullPath($"{ApplicationState.App.Config.ApplicationBasePath}/GameData")); // Todo : Add flag args to enable / disable loading data during server start
                var gameDataMap = GameDataLoader.LoadData(gameDataFiles);
                var gameItems = new List<Item>(); // Todo : Handle game data map loading elsewhere
                // Todo : Move datastore creation to relevant datastore area
                var requiredTables = gameDataMap.Select(x => x.Key).Distinct().ToArray();
                foreach(var table in requiredTables)
                {
                    ApplicationState.App.Datastore.CreateSimpleTable(table);
                }
                var saveItemList = new List<SaveItemInput<string>>(); // Todo: Move this to a more relevant area for datastore handling
                foreach (var dataMap in gameDataMap)
                {
                    foreach(var row in dataMap.Value)
                    {
                        dynamic data = JsonConvert.DeserializeObject<dynamic>(row);
                        saveItemList.Add(new SaveItemInput<string>()
                        {
                            TableName = dataMap.Key,
                            Key = data["id"].Value,
                            Value = row
                        });
                    }
                }
                ApplicationState.App.Datastore.SaveListToDatastore<string>(saveItemList.ToArray());
                CreateHostBuilder(args).Build().Run();
            }
            finally
            {
                ApplicationState.App.Datastore.Cleanup();
            }
        }

        private static void UnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs e)
        {
            log.Fatal((Exception)e.ExceptionObject, "UnhandledExceptionHandler");
        }

        // Additional configuration is required to successfully run gRPC on macOS.
        // For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
