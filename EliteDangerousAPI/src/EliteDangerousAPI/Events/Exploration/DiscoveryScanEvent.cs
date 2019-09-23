using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class DiscoveryScanEvent : JournalEvent
    {
        [JsonProperty("SystemAddress")]
        public long SystemAddress { get; internal set; }

        [JsonProperty("Bodies")]
        public long Bodies { get; internal set; }

        internal static DiscoveryScanEvent Execute(string json, API.EliteDangerousAPI api) => api.Exploration.InvokeEvent(api.FromJson<DiscoveryScanEvent>(json));
    }
}