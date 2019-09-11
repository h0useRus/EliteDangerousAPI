using NSW.EliteDangerous.Events.Entities;
using NSW.EliteDangerous.Internals;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class SynthesisEvent : JournalEvent
    {
        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("Materials")]
        public Material[] Materials { get; internal set; }

        internal static SynthesisEvent Execute(string json, EliteDangerousAPI api) => api.Ship.InvokeEvent(JsonHelper.FromJson<SynthesisEvent>(json));
    }
}