using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class ShipyardNewEvent : JournalEvent
    {
        [JsonProperty("ShipType")]
        public ShipType ShipType { get; internal set; }

        [JsonProperty("ShipType_Localised")]
        public string ShipTypeLocalised { get; internal set; }

        [JsonProperty("NewShipID")]
        public long NewShipId { get; internal set; }

        internal static ShipyardNewEvent Execute(string json, API.EliteDangerousAPI api) => api.StationEvents.InvokeEvent(api.FromJson<ShipyardNewEvent>(json));
    }
}