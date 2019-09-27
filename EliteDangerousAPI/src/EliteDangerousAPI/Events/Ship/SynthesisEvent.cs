using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class SynthesisEvent : JournalEvent
    {
        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("Materials")]
        public Material[] Materials { get; internal set; }

        internal static SynthesisEvent Execute(string json, API.EliteDangerousAPI api) => api.ShipEvents.InvokeEvent(api.FromJson<SynthesisEvent>(json));
    }
}