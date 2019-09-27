using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class SetUserShipNameEvent : JournalEvent
    {
        [JsonProperty("Ship")]
        public string Ship { get; internal set; }

        [JsonProperty("ShipID")]
        public long ShipId { get; internal set; }

        [JsonProperty("UserShipName")]
        public string UserShipName { get; internal set; }

        [JsonProperty("UserShipId")]
        public string UserShipId { get; internal set; }

        internal static SetUserShipNameEvent Execute(string json, API.EliteDangerousAPI api) => api.StationEvents.InvokeEvent(api.FromJson<SetUserShipNameEvent>(json));
    }
}