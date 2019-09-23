using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class NavBeaconScanEvent : JournalEvent
    {
        [JsonProperty("SystemAddress")]
        public long SystemAddress { get; internal set; }

        [JsonProperty("NumBodies")]
        public long NumBodies { get; internal set; }

        internal static NavBeaconScanEvent Execute(string json, API.EliteDangerousAPI api) => api.Exploration.InvokeEvent(api.FromJson<NavBeaconScanEvent>(json));
    }
}