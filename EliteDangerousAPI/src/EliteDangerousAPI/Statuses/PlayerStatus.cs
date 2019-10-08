using System;

namespace NSW.EliteDangerous.API.Statuses
{
    public class PlayerStatus
    {
        private readonly object _lock = new object();

        public string FrontierId { get; private set; }
        public string Commander { get; private set; } = string.Empty;

        public BaseRank<CombatRank> CombatRank { get; } = BaseRank<CombatRank>.Default;
        public BaseRank<TradeRank> TradeRank { get; } = BaseRank<TradeRank>.Default;
        public BaseRank<ExplorationRank> ExplorationRank { get; } = BaseRank<ExplorationRank>.Default;
        public BaseRank<FederationRank> FederationRank { get; } = BaseRank<FederationRank>.Default;
        public BaseRank<EmpireRank> EmpireRank { get; } = BaseRank<EmpireRank>.Default;
        public BaseRank<CqcRank> CqcRank { get; } = BaseRank<CqcRank>.Default;

        public MajorReputation EmpireReputation { get; private set; } = new MajorReputation();
        public MajorReputation FederationReputation { get; private set; } = new MajorReputation();
        public MajorReputation IndependentReputation { get; private set; } = new MajorReputation();
        public MajorReputation AllianceReputation { get; private set; } = new MajorReputation();

        public LegalState LegalState { get; private set; } = LegalState.Clean;

        internal PlayerStatus(EliteDangerousAPI api)
        {
            api.GameEvents.Status += (s, e) =>
            {
                lock (_lock)
                {
                    if (LegalState != e.LegalState)
                    {
                        LegalState = e.LegalState;
                        api.InvokePlayerStatusChanged(this);
                    }
                }
            };

            api.GameEvents.LoadGame += (s, e) =>
            {
                lock (_lock)
                {
                    FrontierId = e.FrontierId;
                    Commander = e.Commander;
                    api.InvokePlayerStatusChanged(this);
                }
            };

            api.GameEvents.ClearSavedGame += (s, e) =>
            {
                lock (_lock)
                {
                    FrontierId = e.FrontierId;
                    Commander = e.Name;
                    api.InvokePlayerStatusChanged(this);
                }
            };

            api.PlayerEvents.NewCommander += (s, e) =>
            {
                lock (_lock)
                {
                    FrontierId = e.FrontierId;
                    Commander = e.Name;
                    api.InvokePlayerStatusChanged(this);
                }
            };

            api.PlayerEvents.Commander += (s, e) =>
            {
                lock (_lock)
                {
                    FrontierId = e.FrontierId;
                    Commander = e.Name;
                    api.InvokePlayerStatusChanged(this);
                }
            };

            api.PlayerEvents.Progress += (s, e) =>
            {
                lock (_lock)
                {
                    CombatRank.Progress = e.Combat;
                    TradeRank.Progress = e.Trade;
                    ExplorationRank.Progress = e.Explore;
                    FederationRank.Progress = e.Federation;
                    EmpireRank.Progress = e.Empire;
                    CqcRank.Progress = e.Cqc;

                    api.InvokePlayerStatusChanged(this);
                }
            };

            api.PlayerEvents.Promotion += (s, e) =>
            {
                lock (_lock)
                {
                    CombatRank.UpdateRank(e.Combat);
                    TradeRank.UpdateRank(e.Trade);
                    ExplorationRank.UpdateRank(e.Explore);
                    EmpireRank.UpdateRank(e.Empire);
                    FederationRank.UpdateRank(e.Federation);
                    CqcRank.UpdateRank(e.Cqc);

                    api.InvokePlayerStatusChanged(this);
                }
            };

            api.PlayerEvents.Rank += (s, e) =>
            {
                lock (_lock)
                {
                    CombatRank.UpdateRank(e.Combat);
                    TradeRank.UpdateRank(e.Trade);
                    ExplorationRank.UpdateRank(e.Explore);
                    EmpireRank.UpdateRank(e.Empire);
                    FederationRank.UpdateRank(e.Federation);
                    CqcRank.UpdateRank(e.Cqc);

                    api.InvokePlayerStatusChanged(this);
                }
            };

            api.PlayerEvents.Reputation += (s, e) =>
            {
                lock (_lock)
                {
                    EmpireReputation = new MajorReputation(e.Empire);
                    FederationReputation = new MajorReputation(e.Federation);
                    IndependentReputation = new MajorReputation(e.Independent);
                    AllianceReputation = new MajorReputation(e.Alliance);

                    api.InvokePlayerStatusChanged(this);
                }
            };
        }
        public class BaseRank<TRank> where TRank : struct, Enum
        {
            public TRank Rank { get; internal set; }
            public byte Progress { get; internal set; }

            public static BaseRank<TRank> Default => new BaseRank<TRank> { Rank = default, Progress = 0 };

            public void UpdateRank(TRank? rank)
            {
                if (rank.HasValue && !Rank.Equals(rank.Value))
                {
                    Rank = rank.Value;
                    Progress = 0;
                }
            }

            public override string ToString() => Rank.ToString();
        }

        public class MajorReputation
        {
            public Reputation Reputation => GetReputation(Level);
            public double Level { get; }

            public MajorReputation() : this(0) { }
            public MajorReputation(double level)
            {
                Level = level;
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

            public override string ToString() => Reputation.ToString();
        }
    }
}