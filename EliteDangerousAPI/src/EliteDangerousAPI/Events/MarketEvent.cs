using NSW.EliteDangerous.Events.Entities;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class MarketEvent : JournalEvent
    {
        [JsonProperty("MarketID")]
        public long MarketId { get; set; }

        [JsonProperty("StationName")]
        public string StationName { get; set; }

        [JsonProperty("StarSystem")]
        public string StarSystem { get; set; }

        [JsonProperty("Items")]
        public MarketItem[] Items { get; set; }

        internal static MarketEvent Execute(string json, EliteDangerousAPI api) => api.Station.InvokeEvent(api.FromJson<MarketEvent>(json));
    }
}