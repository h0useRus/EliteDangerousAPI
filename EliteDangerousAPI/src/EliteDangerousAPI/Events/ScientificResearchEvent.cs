using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class ScientificResearchEvent : JournalEvent
    {
        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("Category")]
        public string Category { get; internal set; }

        [JsonProperty("Count")]
        public long Count { get; internal set; }

        internal static ScientificResearchEvent Execute(string json, API.EliteDangerousAPI api) => api.Station.InvokeEvent(api.FromJson<ScientificResearchEvent>(json));
    }
}