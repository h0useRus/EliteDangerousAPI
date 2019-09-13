using NSW.EliteDangerous.Handlers;

namespace NSW.EliteDangerous
{
    public partial class EliteDangerousAPI
    {
        public GameHandler Game { get; private set; }
        public PlayerHandler Player { get; private set; }
        public ShipHandler Ship { get; private set; }
        public CombatHandler Combat { get; private set; }
        public ExplorationHandler Exploration { get; private set; }
        public StationHandler Station { get; private set; }
        public TradeHandler Trade { get; private set; }
        public TravelHandler Travel { get; private set; }
        public PowerplayHandler Powerplay { get; private set; }
        public WingHandler Wing { get; private set; }
        public SquadronHandler Squadron { get; private set; }
        public CrewHandler Crew { get; private set; }
        public StatusHandler Status { get; private set; }

        private void InitHandlers()
        {
            Game = new GameHandler(this);
            Player = new PlayerHandler(this);
            Ship = new ShipHandler(this);
            Combat = new CombatHandler(this);
            Exploration = new ExplorationHandler(this);
            Station = new StationHandler(this);
            Trade = new TradeHandler(this);
            Travel = new TravelHandler(this);
            Powerplay = new PowerplayHandler(this);
            Wing = new WingHandler();
            Squadron = new SquadronHandler();
            Crew = new CrewHandler(this);
            Status = new StatusHandler(_journalDirectory);
        }
    }
}