using ActionRpg.Server.GameServer.Managers;
using System.Diagnostics;

namespace ActionRpg.Core.Helpers
{
    public class LoggingHelpers
    {
        private readonly string projectName = string.Empty;
        private string logLocation = null;
        private int minLogLevel = 1;
        private enum logLevel
        {
            Trace = 0,
            Verbose = 1,
            Info = 2,
            Error = 3,
            Fatal = 4,
        }

        public LoggingHelpers(string location)
        {
            projectName = LogManager.ProjectName;
            logLocation = location;
        }

        public void SetLogLevel(int minimumLogLevel)
        {
            minLogLevel = minimumLogLevel;
        }

        public void SetLogLocation(string location)
        {
            logLocation = location;
        }

        public void Trace(string message, string enhancedLocation = null, bool allowEnqueue = true, bool allowEcho = true)
        {
            if ((int)logLevel.Trace >= minLogLevel)
            {
                var payload = $@"{projectName}::TRACE::{logLocation} {enhancedLocation}: {message}";
                if (allowEcho)
                {
                    Console.WriteLine(payload);
                    Debug.Print(payload);
                }
                if (allowEnqueue)
                {
                    LogManager.EnqueueLog(payload);
                }
            }
        }

        public void Verbose(string message, string enhancedLocation = null, bool allowEnqueue = true, bool allowEcho = true)
        {
            if ((int)logLevel.Verbose >= minLogLevel)
            {
                var payload = $@"{projectName}::VERBOSE::{logLocation} {enhancedLocation}: {message}";
                if (allowEcho)
                {
                    Console.WriteLine(payload);
                    Debug.Print(payload);
                }
                if (allowEnqueue)
                {
                    LogManager.EnqueueLog(payload);
                }
            }
        }

        public void Info(string message, string enhancedLocation = null, bool allowEnqueue = true, bool allowEcho = true)
        {
            if ((int)logLevel.Info >= minLogLevel)
            {
                var payload = $@"{projectName}::INFO::{logLocation} {enhancedLocation}: {message}";
                if (allowEcho)
                {
                    Console.WriteLine(payload);
                    Debug.Print(payload);
                }
                if (allowEnqueue)
                {
                    LogManager.EnqueueLog(payload);
                }
            }
        }

        public void Error(Exception ex, string enhancedLocation = null, bool allowEnqueue = true, bool allowEcho = true)
        {
            if ((int)logLevel.Error >= minLogLevel)
            {
                var payload = $@"{projectName}::ERROR::{logLocation} {enhancedLocation}: {ex}";
                if (allowEcho)
                {
                    Console.WriteLine(payload);
                    Debug.Print(payload);
                }
                if (allowEnqueue)
                {
                    LogManager.EnqueueLog(payload);
                }
            }
        }

        public void Error(string ex, string enhancedLocation = null, bool allowEnqueue = true, bool allowEcho = true)
        {
            if ((int)logLevel.Error >= minLogLevel)
            {
                var payload = $@"{projectName}::ERROR::{logLocation} {enhancedLocation}: {ex}";
                if (allowEcho)
                {
                    Console.WriteLine(payload);
                    Debug.Print(payload);
                }
                if (allowEnqueue)
                {
                    LogManager.EnqueueLog(payload);
                }
            }

        }

        public void Fatal(Exception ex, string enhancedLocation = null, bool allowEnqueue = true, bool allowEcho = true)
        {
            if ((int)logLevel.Fatal >= minLogLevel)
            {
                var payload = $@"{projectName}::FATAL::{logLocation} {enhancedLocation}: {ex}";
                if (allowEcho)
                {
                    Console.WriteLine(payload);
                    Debug.Print(payload);
                }
                if (allowEnqueue)
                {
                    LogManager.EnqueueLog(payload);
                }
            }
        }
        public void Fatal(string ex, string enhancedLocation = null, bool allowEnqueue = true, bool allowEcho = true)
        {
            if ((int)logLevel.Fatal >= minLogLevel)
            {
                var payload = $@"{projectName}::FATAL::{logLocation} {enhancedLocation}: {ex}";
                if (allowEcho)
                {
                    Console.WriteLine(payload);
                    Debug.Print(payload);
                }
                if (allowEnqueue)
                {
                    LogManager.EnqueueLog(payload);
                }
            }
        }
    }
}
