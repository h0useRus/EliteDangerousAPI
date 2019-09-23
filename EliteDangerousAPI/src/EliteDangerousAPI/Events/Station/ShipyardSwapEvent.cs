using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class ShipyardSwapEvent : JournalEvent
    {
        [JsonProperty("ShipType")]
        public string ShipType { get; internal set; }

        [JsonProperty("ShipType_Localised")]
        public string ShipTypeLocalised { get; internal set; }

        [JsonProperty("ShipID")]
        public long ShipId { get; internal set; }

        [JsonProperty("StoreOldShip")]
        public string StoreOldShip { get; internal set; }

        [JsonProperty("StoreShipID")]
        public long StoreShipId { get; internal set; }

        [JsonProperty("MarketID")]
        public long? MarketId { get; internal set; }

        internal static ShipyardSwapEvent Execute(string json, API.EliteDangerousAPI api) => api.Station.InvokeEvent(api.FromJson<ShipyardSwapEvent>(json));
    }
}