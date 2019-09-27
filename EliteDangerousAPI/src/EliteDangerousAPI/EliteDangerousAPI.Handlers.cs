using NSW.EliteDangerous.API.Handlers;

namespace NSW.EliteDangerous.API
{
    partial class EliteDangerousAPI
    {
        public GameHandler GameEvents { get; private set; }
        public PlayerHandler PlayerEvents { get; private set; }
        public ShipHandler ShipEvents { get; private set; }
        public CombatHandler CombatEvents { get; private set; }
        public ExplorationHandler ExplorationEvents { get; private set; }
        public StationHandler StationEvents { get; private set; }
        public TradeHandler TradeEvents { get; private set; }
        public TravelHandler TravelEvents { get; private set; }
        public PowerplayHandler PowerplayEvents { get; private set; }
        public WingHandler WingEvents { get; private set; }
        public SquadronHandler SquadronEvents { get; private set; }
        public CrewHandler CrewEvents { get; private set; }

        private void InitHandlers()
        {
            GameEvents = new GameHandler(this);
            PlayerEvents = new PlayerHandler(this);
            ShipEvents = new ShipHandler(this);
            CombatEvents = new CombatHandler(this);
            ExplorationEvents = new ExplorationHandler(this);
            StationEvents = new StationHandler(this);
            TradeEvents = new TradeHandler(this);
            TravelEvents = new TravelHandler(this);
            PowerplayEvents = new PowerplayHandler(this);
            WingEvents = new WingHandler(this);
            SquadronEvents = new SquadronHandler(this);
            CrewEvents = new CrewHandler(this);
        }
    }
}