using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class MaterialCollectedEvent : MaterialEvent
    {
        [JsonProperty("Count")]
        public long Count { get; internal set; }

        internal static MaterialCollectedEvent Execute(string json, EliteDangerousAPI api) => api.Exploration.InvokeEvent(api.FromJson<MaterialCollectedEvent>(json));
    }
}