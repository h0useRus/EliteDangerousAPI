using NSW.EliteDangerous.Internals;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class MaterialCollectedEvent : JournalEvent
    {
        [JsonProperty("Category")]
        public string Category { get; internal set; }

        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("Name_Localised")]
        public string NameLocalised { get; internal set; }

        [JsonProperty("Count")]
        public long Count { get; internal set; }

        internal static MaterialCollectedEvent Execute(string json, EliteDangerousAPI api) => api.Exploration.InvokeEvent(JsonHelper.FromJson<MaterialCollectedEvent>(json));
    }
}