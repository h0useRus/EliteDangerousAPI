using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class ShipyardBuyEvent : JournalEvent
    {
        [JsonProperty("ShipType")]
        public ShipType ShipType { get; internal set; }

        [JsonProperty("ShipType_Localised")]
        public string ShipTypeLocalised { get; internal set; }

        [JsonProperty("ShipPrice")]
        public long ShipPrice { get; internal set; }

        [JsonProperty("StoreOldShip")]
        public string StoreOldShip { get; internal set; }

        [JsonProperty("StoreShipID")]
        public long? StoreShipId { get; internal set; }

        [JsonProperty("SellOldShip")]
        public string SellOldShip { get; internal set; }

        [JsonProperty("SellShipID ")]
        public long? SellShipID  { get; internal set; }

        [JsonProperty("SellPrice ")]
        public long? SellPrice  { get; internal set; }

        [JsonProperty("MarketID")]
        public long? MarketId { get; internal set; }

        internal static ShipyardBuyEvent Execute(string json, API.EliteDangerousAPI api) => api.StationEvents.InvokeEvent(api.FromJson<ShipyardBuyEvent>(json));
    }
}