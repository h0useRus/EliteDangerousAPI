using Newtonsoft.Json;
using NSW.EliteDangerous.Events.Entities;

namespace NSW.EliteDangerous.Events
{
    public class ScannedEvent : JournalEvent
    {
        [JsonProperty("ScanType")]
        public ShipScanType ScanType { get; internal set; }

        internal static ScannedEvent Execute(string json, EliteDangerousAPI api) => api.Ship.InvokeEvent(api.FromJson<ScannedEvent>(json));
    }
}