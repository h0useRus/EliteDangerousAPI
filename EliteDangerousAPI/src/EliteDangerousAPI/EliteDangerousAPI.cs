using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;


namespace NSW.EliteDangerous
{
    public partial class EliteDangerousAPI : IDisposable
    {
        private readonly ILogger _log;

        public bool GameRunning => Process.GetProcessesByName("EliteDangerous64").Length > 0;

        public DirectoryInfo JournalDirectory { get; }

        public int DocumentationVersion { get ;} = 25;

        public string Version => Assembly.GetAssembly(typeof(EliteDangerousAPI)).GetCustomAttribute<AssemblyFileVersionAttribute>().Version;

        public EliteDangerousAPI() : this(DefaultJournalDirectory) { }

        public EliteDangerousAPI(ILoggerFactory loggerFactory) : this(DefaultJournalDirectory, loggerFactory) { }

        public EliteDangerousAPI(string journalDirectory) : this(journalDirectory, new NullLoggerFactory()) { }

        public EliteDangerousAPI(string journalDirectory, ILoggerFactory loggerFactory)
        {
            _log = loggerFactory.CreateLogger<EliteDangerousAPI>();
            JournalDirectory = new DirectoryInfo(journalDirectory);
            InitHandlers();
        }
        public void Start()
        {
            if (Status != ApiStatus.Stopped)
                return;

            _log.LogInformation($"Elite Dangerous API v.{Version}");

            StartJournalProcessing();

            _log.LogInformation($"API {Status}");            
        }

        public void Stop()
        {
            if (Status == ApiStatus.Stopped)
                return;

            StopJournalProcessing();

            Status = ApiStatus.Stopped;

            _log.LogInformation($"API {Status}");
        }

        #region IDisposable

        private bool _disposed;
        /// <inheritdoc />
        public void Dispose()
        {
            if (!_disposed)
            {
                Stop();
            }

            _disposed = true;
        }

        #endregion
    }
}