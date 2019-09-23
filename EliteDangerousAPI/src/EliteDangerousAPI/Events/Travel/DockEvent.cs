using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class DockEvent : JournalEvent
    {
        [JsonProperty("StationName")]
        public string StationName { get; internal set; }

        [JsonProperty("StationType")]
        public string StationType { get; internal set; }

        [JsonProperty("MarketID")]
        public long MarketId { get; internal set; }
    }
}