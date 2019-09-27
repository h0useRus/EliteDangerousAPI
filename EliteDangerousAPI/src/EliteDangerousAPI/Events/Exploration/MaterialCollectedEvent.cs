using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class MaterialCollectedEvent : MaterialEvent
    {
        [JsonProperty("Count")]
        public long Count { get; internal set; }

        internal static MaterialCollectedEvent Execute(string json, API.EliteDangerousAPI api) => api.ExplorationEvents.InvokeEvent(api.FromJson<MaterialCollectedEvent>(json));
    }
}