using ActionRpg.Core.Helpers;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ActionRpg.Server.GameServer.Managers
{
    /// <summary>
    /// LogManager handles writing to the file system from 'LoggingHelpers.cs'
    /// This class is not intended to have items enqueued directly. Use LoggingHelpers.
    /// Todo : Eventually update the logger to be less jank. NLog probably
    /// </summary>
    public static class LogManager
    {
        public static string ProjectName { get; set; }
        private static readonly LoggingHelpers log = new LoggingHelpers("LogManager");
        private static readonly BlockingCollection<string> logQueue = new BlockingCollection<string>();
        private static readonly string baseLogPath = Path.GetFullPath($"{ApplicationManager.ApplicationBasePath}/logs");
        private static string currentLogDate = null;
        private const int enqueueTimeout = 1000;
        private const int dequeueTimeout = 1000;
        private const int maxMessageQueue = 100;
        private static readonly TimeSpan dequeueMinimumDelay = TimeSpan.FromMilliseconds(333);
        private static bool shouldAllowEnqueue { get; set; } = true;
        private static bool shouldProcessQueue { get; set; } = true;
        private static bool isInitialized { get; set; } = false;
        private static readonly TimeSpan writeMaximumDelay = TimeSpan.FromSeconds(5);

        static LogManager()
        {
        }

        /// <summary>
        /// Starts the background log processing process
        /// </summary>
        public static void Initialize(string projectName)
        {
            if (isInitialized)
            {
                return;
            }
            ProjectName = projectName;
            var processLogQueue = new BackgroundWorker();
            processLogQueue.DoWork += ProcessLogEnqueuedItems;
            processLogQueue.RunWorkerAsync();

            isInitialized = true;
        }

        /// <summary>
        /// Enqueues a log message for writing. This should only be called by 'LoggingHelpers.cs'
        /// </summary>
        /// <param name="message">Log message to be recorded</param>
        internal static void EnqueueLog(string message)
        {
            if (!shouldAllowEnqueue)
            {
                return;
            }
            try
            {
                var success = logQueue.TryAdd(message, enqueueTimeout);
                if (!success)
                {
                    log.Error($"Failed to enqueue log message: {message}", "EnqueueLog", false);
                }
            }
            catch (Exception)
            {
                log.Error($"Error while trying to enqueue log message: {message}", "EnqueueLog", false);
            }
        }

        /// <summary>
        /// Takes log messages out of the queue for writing
        /// </summary>
        private static void ProcessLogEnqueuedItems(object sender, DoWorkEventArgs e)
        {
            var processQueue = new List<string>(maxMessageQueue);
            do
            {
                while (logQueue.Count > 0 && processQueue.Count < maxMessageQueue)
                {
                    try
                    {
                        var success = logQueue.TryTake(out string message, dequeueTimeout);
                        if (success)
                        {
                            processQueue.Add(message);
                        }
                        else
                        {
                            log.Error($"Processing logline was not successful for {message}", "ProcessLogEnqueuedItems", false);
                        }
                    }
                    catch (Exception ex)
                    {
                        log.Error(ex, "ProcessLogEnqueuedItems", false);
                    }
                }

                if (processQueue.Count > 0)
                {
                    try
                    {
                        var now = DateTime.UtcNow.ToString("yyyy-MM-dd");
                        if (now != currentLogDate)
                        {
                            if (!Directory.Exists(Path.GetFullPath($"{baseLogPath}/{now}/")))
                            {
                                Directory.CreateDirectory(Path.GetFullPath($"{baseLogPath}/{now}/"));
                            }
                            currentLogDate = now;
                        }
                        var writePath = Path.GetFullPath($"{baseLogPath}/{now}/data.log");
                        WriteLogFile(writePath, processQueue.ToArray()).Wait(writeMaximumDelay);
                    }
                    catch (Exception ex)
                    {
                        log.Error(ex, "ProcessLogEnqueuedItems", false);
                    }
                    processQueue.Clear();
                }
                Thread.Sleep(dequeueMinimumDelay);
            } while (shouldProcessQueue);
        }

        /// <summary>
        /// Writes the log messages to the file system
        /// </summary>
        /// <param name="path">Logpath to write the log</param>
        /// <param name="messages">Messages to write to the log</param>
        /// <returns></returns>
        private static async Task WriteLogFile(string path, string[] messages)
        {
            try
            {
                if (messages == null || messages.Length == 0)
                {
                    return;
                }
                using (var file = new FileStream(path: path, mode: FileMode.Append, access: FileAccess.Write, share: FileShare.ReadWrite, bufferSize: 1024))
                {
                    using (var writer = new StreamWriter(file, Encoding.UTF8))
                    {
                        foreach (var line in messages)
                        {
                            var writeTask = writer.WriteLineAsync(line);
                            await writeTask;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex, "WriteLogFile", false);
            }
        }
    }
}
