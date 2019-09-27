using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class SaaSignalsFoundEvent : JournalEvent
    {
        [JsonProperty("SystemAddress")]
        public long SystemAddress { get; internal set; }

        [JsonProperty("BodyName")]
        public string BodyName { get; internal set; }

        [JsonProperty("BodyID")]
        public long BodyId { get; internal set; }

        [JsonProperty("Signals")]
        public SurfaceSignal[] Signals { get; internal set; }

        internal static SaaSignalsFoundEvent Execute(string json, API.EliteDangerousAPI api) => api.ExplorationEvents.InvokeEvent(api.FromJson<SaaSignalsFoundEvent>(json));
    }
}