using System;
using NSW.EliteDangerous.Events.Entities;

namespace NSW.EliteDangerous.Statuses
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

        internal PlayerStatus(EliteDangerousAPI api)
        {
            api.Game.Status += (s, e) =>
            {
                if (e == null) return;

                if(LegalState != e.LegalState)
                {
                    LegalState = e.LegalState;
                    api.InvokePlayerStatusChanged(this);
                }
            };

            api.Game.LoadGame += (s, e) =>
            {
                if (e == null) return;

                FrontierId = e.FrontierId;
                Commander = e.Commander;
                Credits = e.Credits;
                Loan = e.Loan;
                api.InvokePlayerStatusChanged(this);
            };

            api.Game.ClearSavedGame += (s, e) =>
            {
                if (e == null) return;

                FrontierId = e.FrontierId;
                Commander = e.Name;
                api.InvokePlayerStatusChanged(this);
            };

            api.Player.NewCommander += (s, e) =>
            {
                if (e == null) return;

                FrontierId = e.FrontierId;
                Commander = e.Name;
                api.InvokePlayerStatusChanged(this);
            };

            api.Player.Commander += (s, e) =>
            {
                if (e == null) return;

                FrontierId = e.FrontierId;
                Commander = e.Name;
                api.InvokePlayerStatusChanged(this);
            };

            api.Player.Progress += (s, e) =>
            {
                if (e == null) return;

                CombatProgress = e.Combat;
                TradeProgress = e.Trade;
                ExplorationProgress = e.Explore;
                FederationProgress = e.Federation;
                EmpireProgress = e.Empire;
                CqcProgress = e.Cqc;

                api.InvokePlayerStatusChanged(this);
            };

            api.Player.Promotion += (s, e) =>
            {
                if (e == null) return;

                CombatRank = e.Combat ?? CombatRank;
                TradeRank = e.Trade ?? TradeRank;
                ExplorationRank = e.Explore ?? ExplorationRank;
                EmpireRank = e.Empire ?? EmpireRank;
                FederationRank = e.Federation ?? FederationRank;
                CqcRank = e.Cqc ?? CqcRank;

                api.InvokePlayerStatusChanged(this);
            };

            api.Player.Rank += (s, e) =>
            {
                if (e == null) return;

                CombatRank = e.Combat ?? CombatRank;
                TradeRank = e.Trade ?? TradeRank;
                ExplorationRank = e.Explore ?? ExplorationRank;
                EmpireRank = e.Empire ?? EmpireRank;
                FederationRank = e.Federation ?? FederationRank;
                CqcRank = e.Cqc ?? CqcRank;

                api.InvokePlayerStatusChanged(this);
            };

            api.Player.Resurrect += (s, e) =>
            {
                if (e == null) return;

                Bankrupt = e.Bankrupt;
                Credits -= e.Cost;

                api.InvokePlayerStatusChanged(this);
            };

            api.Player.Reputation += (s, e) =>
            {
                if (e == null) return;

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