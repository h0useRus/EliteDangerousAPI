using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class UndockedEvent : JournalEvent
    {
        [JsonProperty("StationName")]
        public string StationName { get; set; }

        [JsonProperty("StationType")]
        public string StationType { get; set; }

        [JsonProperty("MarketID")]
        public long MarketId { get; set; }

        internal static UndockedEvent Execute(string json, EliteDangerousAPI api) => api.Travel.InvokeEvent(api.FromJson<UndockedEvent>(json));
    }
}