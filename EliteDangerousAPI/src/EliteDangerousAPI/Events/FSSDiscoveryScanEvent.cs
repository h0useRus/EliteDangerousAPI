using NSW.EliteDangerous.Internals;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class FssDiscoveryScanEvent : JournalEvent
    {
        [JsonProperty("Progress")]
        public double Progress { get; internal set; }

        [JsonProperty("BodyCount")]
        public long BodyCount { get; internal set; }

        [JsonProperty("NonBodyCount")]
        public long NonBodyCount { get; internal set; }

        internal static FssDiscoveryScanEvent Execute(string json, EliteDangerousAPI api) => api.Exploration.InvokeEvent(JsonHelper.FromJson<FssDiscoveryScanEvent>(json));
    }
}