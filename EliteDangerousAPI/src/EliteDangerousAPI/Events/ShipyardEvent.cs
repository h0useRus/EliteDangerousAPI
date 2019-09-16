using NSW.EliteDangerous.Events.Entities;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class ShipyardEvent : JournalEvent
    {
        [JsonProperty("MarketID")]
        public long MarketId { get; set; }

        [JsonProperty("StationName")]
        public string StationName { get; set; }

        [JsonProperty("StarSystem")]
        public string StarSystem { get; set; }

        [JsonProperty("Horizons")]
        public bool? Horizons { get; set; }

        [JsonProperty("AllowCobraMkIV")]
        public bool? AllowCobraMkIv { get; set; }

        [JsonProperty("PriceList")]
        public ShipyardPrice[] Prices { get; set; }

        internal static ShipyardEvent Execute(string json, EliteDangerousAPI api) => api.Station.InvokeEvent(api.FromJson<ShipyardEvent>(json));
    }
}