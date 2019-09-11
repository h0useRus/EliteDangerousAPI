using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events.Entities
{
    public class FactionStateTrend
    {
        [JsonProperty("State")]
        public string State { get; set; }

        [JsonProperty("Trend")]
        public long? Trend { get; set; }
    }
}