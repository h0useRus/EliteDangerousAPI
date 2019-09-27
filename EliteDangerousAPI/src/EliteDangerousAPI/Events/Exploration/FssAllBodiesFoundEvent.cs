using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class FssAllBodiesFoundEvent : JournalEvent
    {
        [JsonProperty("SystemName")]
        public string SystemName { get; internal set; }

        [JsonProperty("SystemAddress")]
        public long SystemAddress { get; internal set; }

        [JsonProperty("Count")]
        public long Count { get; internal set; }

        internal static FssAllBodiesFoundEvent Execute(string json, API.EliteDangerousAPI api) => api.ExplorationEvents.InvokeEvent(api.FromJson<FssAllBodiesFoundEvent>(json));
    }
}