using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class MaterialDiscardedEvent : MaterialEvent
    {
        [JsonProperty("Count")]
        public long Count { get; internal set; }

        internal static MaterialDiscardedEvent Execute(string json, EliteDangerousAPI api) => api.Exploration.InvokeEvent(api.FromJson<MaterialDiscardedEvent>(json));
    }
}