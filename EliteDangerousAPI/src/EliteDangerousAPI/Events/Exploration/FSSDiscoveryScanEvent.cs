using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class FssDiscoveryScanEvent : JournalEvent
    {
        [JsonProperty("Progress")]
        public double Progress { get; internal set; }

        [JsonProperty("BodyCount")]
        public long BodyCount { get; internal set; }

        [JsonProperty("NonBodyCount")]
        public long NonBodyCount { get; internal set; }

        internal static FssDiscoveryScanEvent Execute(string json, API.EliteDangerousAPI api) => api.ExplorationEvents.InvokeEvent(api.FromJson<FssDiscoveryScanEvent>(json));
    }
}