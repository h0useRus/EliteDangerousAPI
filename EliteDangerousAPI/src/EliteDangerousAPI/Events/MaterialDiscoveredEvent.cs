using NSW.EliteDangerous.Internals;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class MaterialDiscoveredEvent : JournalEvent
    {
        [JsonProperty("Category")]
        public string Category { get; internal set; }

        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("Name_Localised")]
        public string NameLocalised { get; internal set; }

        [JsonProperty("DiscoveryNumber")]
        public long DiscoveryNumber { get; internal set; }

        internal static MaterialDiscoveredEvent Execute(string json, EliteDangerousAPI api) => api.Exploration.InvokeEvent(JsonHelper.FromJson<MaterialDiscoveredEvent>(json));
    }
}