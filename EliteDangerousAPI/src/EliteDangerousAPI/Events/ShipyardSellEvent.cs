using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class ShipyardSellEvent : JournalEvent
    {
        [JsonProperty("ShipType")]
        public string ShipType { get; set; }

        [JsonProperty("ShipType_Localised")]
        public string ShipTypeLocalised { get; set; }

        [JsonProperty("SellShipID")]
        public long SellShipId { get; set; }

        [JsonProperty("ShipPrice")]
        public long ShipPrice { get; set; }

        [JsonProperty("MarketID")]
        public long? MarketId { get; set; }

        [JsonProperty("ShipMarketID")]
        public long? ShipMarketId { get; set; }

        [JsonProperty("System")]
        public string System { get; set; }

        internal static ShipyardSellEvent Execute(string json, API.EliteDangerousAPI api) => api.Station.InvokeEvent(api.FromJson<ShipyardSellEvent>(json));
    }
}