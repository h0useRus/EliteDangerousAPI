using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;


namespace NSW.EliteDangerous
{
    internal partial class EliteDangerousAPI : IEliteDangerousAPI
    {
        private readonly ILogger _log;
        private readonly ApiOptions _settings;

        public bool GameRunning => Process.GetProcessesByName("EliteDangerous64").Length > 0;

        public DirectoryInfo JournalDirectory { get; }

        public int DocumentationVersion { get ;} = 25;

        public string Version => Assembly.GetAssembly(typeof(EliteDangerousAPI)).GetCustomAttribute<AssemblyFileVersionAttribute>().Version;

        public EliteDangerousAPI(IOptions<ApiOptions> options, ILoggerFactory loggerFactory)
        {
            _settings = options?.Value ?? ApiOptions.Default;
            _log = loggerFactory.CreateLogger<EliteDangerousAPI>();
            JournalDirectory = new DirectoryInfo(_settings.JournalDirectory);
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