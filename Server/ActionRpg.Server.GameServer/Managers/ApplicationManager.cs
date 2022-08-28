namespace ActionRpg.Server.GameServer.Managers
{
    public class ApplicationManager

    {
        /// <summary>
        /// Base path of the application runtime. This is the root folder where things like logs / mocks are handled
        /// </summary>
        public static string ApplicationBasePath { get; internal set; }
        /// <summary>
        /// Generic lock object when reading/writing to disk for jobs that work in shared areas.
        /// </summary>
        public static object SharedFileLock { get; set; } = new object();

        public ApplicationManager(string projectName)
        {
            LogManager.Initialize(projectName);
        }
    }
}
