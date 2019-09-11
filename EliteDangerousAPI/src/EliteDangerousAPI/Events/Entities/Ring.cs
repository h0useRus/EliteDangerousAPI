using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events.Entities
{
    public class Ring
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("RingClass")]
        public string RingClass { get; set; }

        [JsonProperty("MassMT")]
        public long MassMt { get; set; }

        [JsonProperty("InnerRad")]
        public long InnerRad { get; set; }

        [JsonProperty("OuterRad")]
        public long OuterRad { get; set; }
    }
}