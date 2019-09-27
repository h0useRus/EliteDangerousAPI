using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class SellExplorationDataEvent : JournalEvent
    {
        [JsonProperty("Systems")]
        public string[] Systems { get; internal set; }

        [JsonProperty("Discovered")]
        public string[] Discovered { get; internal set; }

        [JsonProperty("BaseValue")]
        public long BaseValue { get; internal set; }

        [JsonProperty("Bonus")]
        public long Bonus { get; internal set; }

        [JsonProperty("TotalEarnings")]
        public long TotalEarnings { get; internal set; }

        internal static SellExplorationDataEvent Execute(string json, API.EliteDangerousAPI api) => api.ExplorationEvents.InvokeEvent(api.FromJson<SellExplorationDataEvent>(json));
    }
}