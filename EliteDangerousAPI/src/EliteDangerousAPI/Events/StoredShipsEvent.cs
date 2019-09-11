using NSW.EliteDangerous.Events.Entities;
using NSW.EliteDangerous.Internals;
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

        internal static StoredShipsEvent Execute(string json, EliteDangerousAPI api) => api.Station.InvokeEvent(JsonHelper.FromJson<StoredShipsEvent>(json));
    }
}