namespace NSW.EliteDangerous.API.Statuses
{
    public class PlayerStatus
    {
        public string FrontierId { get; private set; }
        public string Commander { get; private set; } = string.Empty;

        public long Credits { get; private set; }
        public long Loan { get; private set; }
        public bool Bankrupt { get; set; }

        public CombatRank CombatRank { get; private set; } = CombatRank.Harmless;
        public TradeRank TradeRank { get; private set; } = TradeRank.Penniless;
        public ExplorationRank  ExplorationRank  { get; private set; } = ExplorationRank.Aimless;
        public FederationRank FederationRank { get; private set; } = FederationRank.None;
        public EmpireRank EmpireRank { get; private set; } = EmpireRank.None;
        public CqcRank CqcRank { get; private set; } = CqcRank.Helpless;

        public byte CombatProgress { get; private set; }
        public byte TradeProgress { get; private set; }
        public byte ExplorationProgress { get; private set; }
        public byte EmpireProgress { get; private set; }
        public byte FederationProgress { get; private set; }
        public byte CqcProgress { get; private set; }

        public Reputation EmpireReputation { get; private set; } = Reputation.Neutral;
        public Reputation FederationReputation { get; private set; } = Reputation.Neutral;
        public Reputation IndependentReputation { get; private set; } = Reputation.Neutral;
        public Reputation AllianceReputation { get; private set; } = Reputation.Neutral;

        public LegalState LegalState { get; private set; } = LegalState.Clean;

        internal PlayerStatus(API.EliteDangerousAPI api)
        {
            api.GameEvents.Status += (s, e) =>
            {
                if(LegalState != e.LegalState)
                {
                    LegalState = e.LegalState;
                    api.InvokePlayerStatusChanged(this);
                }
            };

            api.GameEvents.LoadGame += (s, e) =>
            {
                FrontierId = e.FrontierId;
                Commander = e.Commander;
                Credits = e.Credits;
                Loan = e.Loan;
                api.InvokePlayerStatusChanged(this);
            };

            api.GameEvents.ClearSavedGame += (s, e) =>
            {
                FrontierId = e.FrontierId;
                Commander = e.Name;
                api.InvokePlayerStatusChanged(this);
            };

            api.PlayerEvents.NewCommander += (s, e) =>
            {
                FrontierId = e.FrontierId;
                Commander = e.Name;
                api.InvokePlayerStatusChanged(this);
            };

            api.PlayerEvents.Commander += (s, e) =>
            {
                FrontierId = e.FrontierId;
                Commander = e.Name;
                api.InvokePlayerStatusChanged(this);
            };

            api.PlayerEvents.Progress += (s, e) =>
            {
                CombatProgress = e.Combat;
                TradeProgress = e.Trade;
                ExplorationProgress = e.Explore;
                FederationProgress = e.Federation;
                EmpireProgress = e.Empire;
                CqcProgress = e.Cqc;

                api.InvokePlayerStatusChanged(this);
            };

            api.PlayerEvents.Promotion += (s, e) =>
            {
                CombatRank = e.Combat ?? CombatRank;
                TradeRank = e.Trade ?? TradeRank;
                ExplorationRank = e.Explore ?? ExplorationRank;
                EmpireRank = e.Empire ?? EmpireRank;
                FederationRank = e.Federation ?? FederationRank;
                CqcRank = e.Cqc ?? CqcRank;

                api.InvokePlayerStatusChanged(this);
            };

            api.PlayerEvents.Rank += (s, e) =>
            {
                CombatRank = e.Combat ?? CombatRank;
                TradeRank = e.Trade ?? TradeRank;
                ExplorationRank = e.Explore ?? ExplorationRank;
                EmpireRank = e.Empire ?? EmpireRank;
                FederationRank = e.Federation ?? FederationRank;
                CqcRank = e.Cqc ?? CqcRank;

                api.InvokePlayerStatusChanged(this);
            };

            api.PlayerEvents.Resurrect += (s, e) =>
            {
                Bankrupt = e.Bankrupt;
                Credits -= e.Cost;

                api.InvokePlayerStatusChanged(this);
            };

            api.PlayerEvents.Reputation += (s, e) =>
            {
                EmpireReputation = GetReputation(e.Empire);
                FederationReputation = GetReputation(e.Federation);
                IndependentReputation = GetReputation(e.Independent);
                AllianceReputation = GetReputation(e.Alliance);

                api.InvokePlayerStatusChanged(this);
            };
        }

        private static Reputation GetReputation(double reputation)
        {
            if (reputation < -90) return Reputation.Hostile;
            if (reputation < -35) return Reputation.Unfriendly;
            if (reputation < 4) return Reputation.Neutral;
            if (reputation < 35) return Reputation.Cordial;
            if (reputation < 90) return Reputation.Friendly;
            return Reputation.Allied;
        }
    }
}