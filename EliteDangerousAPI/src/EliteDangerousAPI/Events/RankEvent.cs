using NSW.EliteDangerous.Events.Entities;
using NSW.EliteDangerous.Internals;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class RankEvent : JournalEvent
    {
        [JsonProperty("Combat")]
        public CombatRank? Combat { get; internal set; }

        [JsonProperty("Trade")]
        public TradeRank? Trade { get; internal set; }

        [JsonProperty("Explore")]
        public ExplorationRank? Explore { get; internal set; }

        [JsonProperty("Empire")]
        public EmpireRank? Empire { get; internal set; }

        [JsonProperty("Federation")]
        public FederationRank? Federation { get; internal set; }

        [JsonProperty("CQC")]
        public CqcRank? Cqc { get; internal set; }

        internal static RankEvent Execute(string json, EliteDangerousAPI api) => api.Player.InvokeEvent(JsonHelper.FromJson<RankEvent>(json));
    }
}