using System;
using System.IO;
using System.Linq;
using NSW.EliteDangerous.Events;

namespace NSW.EliteDangerous
{
    public partial class EliteDangerousAPI
    {
        public DirectoryInfo JournalDirectory { get; }

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

        public int DocumentationVersion { get ;} = 25;

        public EliteDangerousAPI() : this(DefaultJournalDirectory)
        {
            
        }

        public EliteDangerousAPI(string journalDirectory)
        {
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

            var journalFile = JournalDirectory.GetFiles("Journal.*").OrderByDescending(x => x.LastWriteTime).FirstOrDefault();

            if (journalFile != null)
            {

            }

            Status.Start();

            ApiStatus = ApiStatus.Running;

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