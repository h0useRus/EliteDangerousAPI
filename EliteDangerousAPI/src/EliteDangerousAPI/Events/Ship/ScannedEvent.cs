using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class ScannedEvent : JournalEvent
    {
        [JsonProperty("ScanType")]
        public ShipScanType ScanType { get; internal set; }

        internal static ScannedEvent Execute(string json, API.EliteDangerousAPI api) => api.Ship.InvokeEvent(api.FromJson<ScannedEvent>(json));
    }
}