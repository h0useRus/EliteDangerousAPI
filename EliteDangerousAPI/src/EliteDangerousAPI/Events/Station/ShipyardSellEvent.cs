using Newtonsoft.Json;
using NSW.EliteDangerous.API.Internals;

namespace NSW.EliteDangerous.API.Events
{
    public class ShipyardSellEvent : JournalEvent
    {
        [JsonProperty("ShipType")]
        public string ShipType { get; set; }

        [JsonIgnore] public ShipModel ShipModel => EnumHelper.GetShipModel(ShipType);

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

        internal static ShipyardSellEvent Execute(string json, API.EliteDangerousAPI api) => api.StationEvents.InvokeEvent(api.FromJson<ShipyardSellEvent>(json));
    }
}