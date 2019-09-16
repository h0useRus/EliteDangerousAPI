using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class DataScannedEvent : JournalEvent
    {
        [JsonProperty("Type")]
        public string Type { get; internal set; }

        [JsonProperty("Type_Localised")]
        public string TypeLocalised { get; internal set; }

        internal static DataScannedEvent Execute(string json, EliteDangerousAPI api) => api.Exploration.InvokeEvent(api.FromJson<DataScannedEvent>(json));
    }
}