using System;
using System.IO;
using NSW.EliteDangerous.Events;
using NSW.EliteDangerous.Internals;

namespace NSW.EliteDangerous
{
    public partial class EliteDangerousAPI
    {
        private readonly DirectoryInfo _journalDirectory;

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

        public EliteDangerousAPI() : this(FileHelpers.GetJournalDirectory())
        {
            
        }

        public EliteDangerousAPI(string journalDirectory)
        {
            _journalDirectory = new DirectoryInfo(journalDirectory);

            InitHandlers();
        }

        public ApiStatus Start()
        {
            if (ApiStatus != ApiStatus.Stopped)
                return ApiStatus;

            if (!_journalDirectory.Exists)
            {
                ApiStatus = ApiStatus.GameNotFound;
                return ApiStatus;
            }

            Status.Start();

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