using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class MaterialDiscoveredEvent : MaterialEvent
    {
        [JsonProperty("DiscoveryNumber")]
        public long DiscoveryNumber { get; internal set; }

        internal static MaterialDiscoveredEvent Execute(string json, EliteDangerousAPI api) => api.Exploration.InvokeEvent(api.FromJson<MaterialDiscoveredEvent>(json));
    }
}