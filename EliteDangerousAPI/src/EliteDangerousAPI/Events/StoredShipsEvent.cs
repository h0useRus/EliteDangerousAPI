using NSW.EliteDangerous.Events.Entities;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
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

        internal static StoredShipsEvent Execute(string json, API.EliteDangerousAPI api) => api.Station.InvokeEvent(api.FromJson<StoredShipsEvent>(json));
    }
}