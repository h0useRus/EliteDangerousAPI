using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class ShipyardNewEvent : JournalEvent
    {
        [JsonProperty("ShipType")]
        public string ShipType { get; internal set; }

        [JsonProperty("ShipType_Localised")]
        public string ShipTypeLocalised { get; internal set; }

        [JsonProperty("NewShipID")]
        public long NewShipId { get; internal set; }

        internal static ShipyardNewEvent Execute(string json, EliteDangerousAPI api) => api.Station.InvokeEvent(api.FromJson<ShipyardNewEvent>(json));
    }
}