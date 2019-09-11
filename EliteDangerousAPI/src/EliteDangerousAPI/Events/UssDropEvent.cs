using NSW.EliteDangerous.Internals;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class UssDropEvent : JournalEvent
    {
        [JsonProperty("USSType")]
        public string UssType { get; set; }

        [JsonProperty("USSType_Localised")]
        public string UssTypeLocalised { get; set; }

        [JsonProperty("USSThreat")]
        public int UssThreat { get; set; }

        internal static UssDropEvent Execute(string json, EliteDangerousAPI api) => api.Exploration.InvokeEvent(JsonHelper.FromJson<UssDropEvent>(json));
    }
}