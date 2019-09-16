using NSW.EliteDangerous.Events.Entities;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class MultiSellExplorationDataEvent : JournalEvent
    {
        [JsonProperty("Discovered")]
        public ExplorationData[] Discovered { get; internal set; }

        [JsonProperty("BaseValue")]
        public long BaseValue { get; internal set; }

        [JsonProperty("Bonus")]
        public long Bonus { get; internal set; }

        [JsonProperty("TotalEarnings")]
        public long TotalEarnings { get; internal set; }

        internal static MultiSellExplorationDataEvent Execute(string json, EliteDangerousAPI api) => api.Exploration.InvokeEvent(api.FromJson<MultiSellExplorationDataEvent>(json));
    }
}