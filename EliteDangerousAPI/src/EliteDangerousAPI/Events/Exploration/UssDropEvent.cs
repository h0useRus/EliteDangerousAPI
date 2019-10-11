using Newtonsoft.Json;
using NSW.EliteDangerous.API.Internals.Converters;

namespace NSW.EliteDangerous.API.Events
{
    public class UssDropEvent : JournalEvent
    {
        [JsonProperty("USSType")]
        [JsonConverter(typeof(UssTypeConverter))]
        public UssType UssType { get; set; }

        [JsonProperty("USSType_Localised")]
        public string UssTypeLocalised { get; set; }

        [JsonProperty("USSThreat")]
        public int UssThreat { get; set; }

        internal static UssDropEvent Execute(string json, API.EliteDangerousAPI api) => api.ExplorationEvents.InvokeEvent(api.FromJson<UssDropEvent>(json));
    }
}