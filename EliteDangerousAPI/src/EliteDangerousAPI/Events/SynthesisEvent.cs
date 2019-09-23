using Newtonsoft.Json;
using NSW.EliteDangerous.API;

namespace NSW.EliteDangerous.Events
{
    public class SynthesisEvent : JournalEvent
    {
        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("Materials")]
        public Material[] Materials { get; internal set; }

        internal static SynthesisEvent Execute(string json, API.EliteDangerousAPI api) => api.Ship.InvokeEvent(api.FromJson<SynthesisEvent>(json));
    }
}