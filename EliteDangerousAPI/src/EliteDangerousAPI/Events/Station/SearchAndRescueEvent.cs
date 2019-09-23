using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class SearchAndRescueEvent : JournalEvent
    {
        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("Name_Localised")]
        public string NameLocalised { get; internal set; }

        [JsonProperty("MarketID")]
        public long MarketId { get; internal set; }

        [JsonProperty("Count")]
        public int Count { get; internal set; }

        [JsonProperty("Reward")]
        public long Reward { get; internal set; }

        internal static SearchAndRescueEvent Execute(string json, API.EliteDangerousAPI api) => api.Station.InvokeEvent(api.FromJson<SearchAndRescueEvent>(json));
    }
}