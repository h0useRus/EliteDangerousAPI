using Newtonsoft.Json;
using NSW.EliteDangerous.API.Internals.Converters;

namespace NSW.EliteDangerous.API
{
    public class Ring
    {
        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("RingClass")]
        [JsonConverter(typeof(RingClassConverter))]
        public RingClass RingClass { get; internal set; }

        [JsonProperty("MassMT")]
        public double MassMt { get; internal set; }

        [JsonProperty("InnerRad")]
        public double InnerRad { get; internal set; }

        [JsonProperty("OuterRad")]
        public double OuterRad { get; internal set; }
    }
}