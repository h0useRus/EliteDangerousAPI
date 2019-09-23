using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class DatalinkScanEvent : JournalEvent
    {
        [JsonProperty("Message")]
        public string Message { get; internal set; }

        [JsonProperty("Message_Localised")]
        public string MessageLocalised { get; internal set; }

        internal static DatalinkScanEvent Execute(string json, API.EliteDangerousAPI api) => api.Exploration.InvokeEvent(api.FromJson<DatalinkScanEvent>(json));
    }
}