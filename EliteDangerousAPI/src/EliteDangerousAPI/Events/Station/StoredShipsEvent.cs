using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class StoredShipsEvent : JournalEvent
    {
        [JsonProperty("StationName")]
        public string StationName { get; set; }

        [JsonProperty("MarketID")]
        public long MarketId { get; set; }

        [JsonProperty("StarSystem")]
        public string StarSystem { get; set; }

        [JsonProperty("ShipsHere")]
        public ShipStoredLocal[] ShipsHere { get; set; }

        [JsonProperty("ShipsRemote")]
        public ShipStoredRemote[] ShipsRemote { get; set; }

        internal static StoredShipsEvent Execute(string json, API.EliteDangerousAPI api) => api.StationEvents.InvokeEvent(api.FromJson<StoredShipsEvent>(json));
    }
}