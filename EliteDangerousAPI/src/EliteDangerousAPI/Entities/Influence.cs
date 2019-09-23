using Newtonsoft.Json;

namespace NSW.EliteDangerous.API
{
    public class Influence
    {
        [JsonProperty("SystemAddress")]
        public long SystemAddress { get; internal set; }

        [JsonProperty("Trend")]
        public string Trend { get; internal set; }

        [JsonProperty("Influence")]
        public string InfluenceValue { get; internal set; }
    }
}