using ActionRpg.Core.Helpers;
using ActionRpg.Models.DatastoreCoreModels;
using ActionRpg.Models.ItemModels;
using ActionRpg.Server.GameServer.Converter;
using ActionRpg.Server.GameServer.Loaders;
using ActionRpg.Server.GameServer.Managers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;

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
                // Todo : Move datastore creation to relevant datastore area
                ApplicationState.App.Datastore.CreateTable(new CreateTableInput()
                {
                    TableName = "items",
                    Fields = new TableFieldInput[2]
                    {
                    new TableFieldInput()
                    {
                        FieldName = "key",
                        FieldType = "string",
                        MaxLength = 100,
                        IsPrimaryKey = true,
                        IsNullable = false,
                    },
                    new TableFieldInput()
                    {
                        FieldName = "data",
                        FieldType = "text",
                        IsNullable = false,
                    }
                    },
                    TableIndexes = new TableIndexInput[1]
                    {
                    new TableIndexInput()
                    {
                        IndexName = "uix_items_key",
                        IndexType = Models.ServerConstants.TableIndexType.Unique,
                        Fields = new string[1] { "key" }
                    }
                    }
                });
                var gameDataFiles = GameDataLoader.LoadFileList(Path.GetFullPath($"{ApplicationState.App.Config.ApplicationBasePath}/GameData")); // Todo : Add flag args to enable / disable loading data during server start
                var gameDataMap = GameDataLoader.LoadData(gameDataFiles);
                var gameItems = new List<Item>(); // Todo : Handle game data map loading elsewhere
                foreach (var dataMap in gameDataMap)
                {
                    switch (dataMap.Key)
                    {
                        case "items":
                        {
                            foreach (var item in dataMap.Value)
                            {
                                gameItems.Add(item.JsonToGameItem());
                            }
                            break;
                        }
                        default:
                        {
                            throw new NotImplementedException($"Unknown datamap key: {dataMap.Key}. Count: {dataMap.Value.Length}");
                        }
                    }
                }
                var saveItemList = new List<SaveItemInput<Item>>(); // Todo: Move this to a more relevant area for datastore handling
                foreach (var item in gameItems)
                {
                    saveItemList.Add(new SaveItemInput<Item>()
                    {
                        TableName = "items",
                        Key = item.ItemID,
                        Value = item
                    });
                }
                ApplicationState.App.Datastore.SaveListToDatastore<Item>(saveItemList.ToArray());
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
