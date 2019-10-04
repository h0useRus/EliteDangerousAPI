using System.Diagnostics;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;

namespace NSW.EliteDangerous.API
{
    internal partial class EliteDangerousAPI : IEliteDangerousAPI
    {
        private readonly ILogger _log;
        private readonly ApiOptions _settings;

        internal static bool GameRunning => Process.GetProcessesByName("EliteDangerous64").Length > 0;

        public DirectoryInfo JournalDirectory { get; }

        public int DocumentationVersion { get ;} = 26;

        public string Version => Assembly.GetAssembly(typeof(EliteDangerousAPI)).GetCustomAttribute<AssemblyFileVersionAttribute>().Version;

        public EliteDangerousAPI(IOptions<ApiOptions> options, ILoggerFactory loggerFactory = null)
        {
            _settings = options?.Value ?? new ApiOptions();
            _log = (loggerFactory ?? new NullLoggerFactory()).CreateLogger<EliteDangerousAPI>();
            JournalDirectory = new DirectoryInfo(_settings.JournalDirectory);
            InitHandlers();
            InitStatuses();
            InitPlugins();

            if(_settings.AutoRun)
                Start();
        }
        public void Start()
        {
            if (Status != ApiStatus.Stopped)
                return;

            _log.LogInformation($"Elite Dangerous API v.{Version} ({DocumentationVersion})");

            StartJournalProcessing();
            StartPlugins();

            _log.LogInformation($"API {Status}");            
        }

        public void Stop()
        {
            if (Status == ApiStatus.Stopped)
                return;

            StopPlugins();
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