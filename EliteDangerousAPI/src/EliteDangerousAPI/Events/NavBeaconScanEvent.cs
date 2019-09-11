using NSW.EliteDangerous.Internals;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class NavBeaconScanEvent : JournalEvent
    {
        [JsonProperty("SystemAddress")]
        public long SystemAddress { get; internal set; }

        [JsonProperty("NumBodies")]
        public long NumBodies { get; internal set; }

        internal static NavBeaconScanEvent Execute(string json, EliteDangerousAPI api) => api.Exploration.InvokeEvent(JsonHelper.FromJson<NavBeaconScanEvent>(json));
    }
}