using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class DatalinkScanEvent : JournalEvent
    {
        [JsonProperty("Message")]
        public string Message { get; internal set; }

        [JsonProperty("Message_Localised")]
        public string MessageLocalised { get; internal set; }

        internal static DatalinkScanEvent Execute(string json, EliteDangerousAPI api) => api.Exploration.InvokeEvent(api.FromJson<DatalinkScanEvent>(json));
    }
}