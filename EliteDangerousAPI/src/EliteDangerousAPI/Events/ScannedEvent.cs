using NSW.EliteDangerous.Internals;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class ScannedEvent : JournalEvent
    {
        [JsonProperty("ScanType")]
        public string ScanType { get; internal set; }

        internal static ScannedEvent Execute(string json, EliteDangerousAPI api) => api.Ship.InvokeEvent(JsonHelper.FromJson<ScannedEvent>(json));
    }
}