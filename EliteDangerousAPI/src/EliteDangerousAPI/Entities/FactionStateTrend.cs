using Newtonsoft.Json;

namespace NSW.EliteDangerous.API
{
    public class FactionStateTrend
    {
        [JsonProperty("State")]
        public State State { get; set; }

        [JsonProperty("Trend")]
        public long? Trend { get; set; }
    }
}