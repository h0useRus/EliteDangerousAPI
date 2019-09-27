using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class UssDropEvent : JournalEvent
    {
        [JsonProperty("USSType")]
        public string UssType { get; set; }

        [JsonProperty("USSType_Localised")]
        public string UssTypeLocalised { get; set; }

        [JsonProperty("USSThreat")]
        public int UssThreat { get; set; }

        internal static UssDropEvent Execute(string json, API.EliteDangerousAPI api) => api.ExplorationEvents.InvokeEvent(api.FromJson<UssDropEvent>(json));
    }
}