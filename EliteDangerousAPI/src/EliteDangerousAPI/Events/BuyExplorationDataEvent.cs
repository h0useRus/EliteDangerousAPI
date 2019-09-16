using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class BuyExplorationDataEvent : JournalEvent
    {
        [JsonProperty("System")]
        public string System { get; internal set; }

        [JsonProperty("Cost")]
        public long Cost { get; internal set; }

        internal static BuyExplorationDataEvent Execute(string json, EliteDangerousAPI api) => api.Exploration.InvokeEvent(api.FromJson<BuyExplorationDataEvent>(json));
    }
}