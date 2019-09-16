using System.Collections.Generic;
using NSW.EliteDangerous.Events.Entities;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class StatisticsEvent : JournalEvent
    {
        [JsonProperty("Bank_Account")]
        public BankStatistics BankAccount { get; internal set; }

        [JsonProperty("Combat")]
        public CombatStatistics Combat { get; internal set; }

        [JsonProperty("Crime")]
        public CrimeStatistics Crime { get; internal set; }

        [JsonProperty("Smuggling")]
        public SmugglingStatistics Smuggling { get; internal set; }

        [JsonProperty("Trading")]
        public TradingStatistics Trading { get; internal set; }

        [JsonProperty("Mining")]
        public MiningStatistics Mining { get; internal set; }

        [JsonProperty("Exploration")]
        public ExplorationStatistics Exploration { get; internal set; }

        [JsonProperty("Passengers")]
        public PassengersStatistics Passengers { get; internal set; }

        [JsonProperty("Search_And_Rescue")]
        public SearchAndRescueStatistics SearchAndRescue { get; internal set; }

        [JsonProperty("TG_ENCOUNTERS")]
        public ThargoidEncountersStatistics TgEncounters { get; internal set; }

        [JsonProperty("Crafting")]
        public CraftingStatistics Crafting { get; internal set; }

        [JsonProperty("Crew")]
        public NpcCrewStatistics NpcCrew { get; internal set; }

        [JsonProperty("Multicrew")]
        public MultiCrewStatistics MultiCrew { get; internal set; }

        [JsonProperty("Material_Trader_Stats")]
        public MaterialTraderStatistics MaterialTraderStats { get; internal set; }

        [JsonProperty("CQC")]
        public Dictionary<string, double> Cqc { get; internal set; }

        internal static StatisticsEvent Execute(string json, EliteDangerousAPI api) => api.Player.InvokeEvent(api.FromJson<StatisticsEvent>(json));
    }
}