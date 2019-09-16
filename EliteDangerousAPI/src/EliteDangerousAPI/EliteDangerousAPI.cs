using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using NSW.EliteDangerous.Events;

namespace NSW.EliteDangerous
{
    public partial class EliteDangerousAPI
    {
        private readonly ILogger _log;
        private ApiStatus _apiStatus;
        public ApiStatus ApiStatus
        {
            get => _apiStatus;
            internal set
            {
                if(_apiStatus != value)
                {
                    _apiStatus = value;
                    StatusChanged?.Invoke(this, _apiStatus);
                }
            }
        }

        public DirectoryInfo JournalDirectory { get; }
        public FileInfo CurrentJournalFile { get; internal set; }

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

        public ApiStatus Start()
        {
            if (ApiStatus != ApiStatus.Stopped)
                return ApiStatus;

            if (!JournalDirectory.Exists)
            {
                ApiStatus = ApiStatus.GameNotFound;
                return ApiStatus;
            }

            CurrentJournalFile = JournalDirectory.GetFiles("Journal.*").OrderByDescending(x => x.LastWriteTime).FirstOrDefault();

            Status.Start();

            ApiStatus = CurrentJournalFile != null ? ApiStatus.Running : ApiStatus.Pending;

            return ApiStatus;
        }

        public ApiStatus Stop()
        {
            if (ApiStatus == ApiStatus.Stopped)
                return ApiStatus;

            Status.Stop();

            return ApiStatus.GameNotFound;
        }

        public event EventHandler<ApiStatus> StatusChanged;
        public event EventHandler<GlobalEvent> AllEvents;
    }
}