using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events.Entities
{
    public class Influence
    {
        [JsonProperty("SystemAddress")]
        public long SystemAddress { get; set; }

        [JsonProperty("Trend")]
        public string Trend { get; set; }

        [JsonProperty("Influence")]
        public string InfluenceValue { get; set; }
    }
}