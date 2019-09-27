using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class UndockedEvent : JournalEvent
    {
        [JsonProperty("StationName")]
        public string StationName { get; set; }

        [JsonProperty("StationType")]
        public string StationType { get; set; }

        [JsonProperty("MarketID")]
        public long MarketId { get; set; }

        internal static UndockedEvent Execute(string json, API.EliteDangerousAPI api) => api.TravelEvents.InvokeEvent(api.FromJson<UndockedEvent>(json));
    }
}