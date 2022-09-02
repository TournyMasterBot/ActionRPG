using ActionRpg.Core.Helpers;
using ActionRpg.Models.ItemModels;
using ActionRpg.Server.GameServer.Loaders;
using ActionRpg.Server.GameServer.Managers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;

namespace ActionRpg.Server.Grpc
{
    public class Program
    {
        private static LoggingHelpers log { get; set; }

        public static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionHandler;
            ApplicationState.Init("beta"); // Todo : Support args to switch beta/prod
            log = new LoggingHelpers("Program");
            var gameDataFiles = GameDataLoader.LoadFileList(Path.GetFullPath($"{ApplicationState.App.Config.ApplicationBasePath}/GameData")); // Todo : Add flag args to enable / disable loading data during server start
            var gameDataMap = GameDataLoader.LoadData(gameDataFiles);
            var importGameDataSuccess = ApplicationState.App.Datastore.ImportDataToDatastore(gameDataMap);
            if(importGameDataSuccess != true)
            {
                log.Fatal("Failed to import game data", "ImportDataToDatastore");
                return;
            }
            CreateHostBuilder(args).Build().Run();
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
