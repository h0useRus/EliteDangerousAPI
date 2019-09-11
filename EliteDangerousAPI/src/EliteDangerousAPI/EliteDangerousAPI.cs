using NSW.EliteDangerous.Handlers;
using System;
using System.IO;
using NSW.EliteDangerous.Internals;

namespace NSW.EliteDangerous
{
    public partial class EliteDangerousAPI
    {
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
        private readonly DirectoryInfo _journalDirectory;

        public GameHandler Game { get; }
        public PlayerHandler Player { get; }
        public ShipHandler Ship { get; }
        public CombatHandler Combat { get; }
        public ExplorationHandler Exploration { get; }
        public StationHandler Station { get; }
        public TradeHandler Trade { get; }
        public TravelHandler Travel { get; }
        public PowerplayHandler Powerplay { get; }
        public WingHandler Wing { get; }
        public SquadronHandler Squadron { get; }
        public CrewHandler Crew { get; }
        public StatusHandler Status { get; }

        public EliteDangerousAPI() : this(FileHelpers.GetJournalDirectory())
        {
            
        }

        public EliteDangerousAPI(string journalDirectory)
        {
            _journalDirectory = new DirectoryInfo(journalDirectory);

            Game = new GameHandler(this);
            Player = new PlayerHandler(this);
            Ship = new ShipHandler(this);
            Combat = new CombatHandler();
            Exploration = new ExplorationHandler();
            Station = new StationHandler();
            Trade = new TradeHandler(this);
            Travel = new TravelHandler();
            Powerplay = new PowerplayHandler(this);
            Wing = new WingHandler();
            Squadron = new SquadronHandler();
            Crew = new CrewHandler();
            Status = new StatusHandler(_journalDirectory);
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
    }
}