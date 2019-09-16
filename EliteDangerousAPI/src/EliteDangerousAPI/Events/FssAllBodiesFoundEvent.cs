using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class FssAllBodiesFoundEvent : JournalEvent
    {
        [JsonProperty("SystemName")]
        public string SystemName { get; internal set; }

        [JsonProperty("SystemAddress")]
        public long SystemAddress { get; internal set; }

        [JsonProperty("Count")]
        public long Count { get; internal set; }

        internal static FssAllBodiesFoundEvent Execute(string json, EliteDangerousAPI api) => api.Exploration.InvokeEvent(api.FromJson<FssAllBodiesFoundEvent>(json));
    }
}