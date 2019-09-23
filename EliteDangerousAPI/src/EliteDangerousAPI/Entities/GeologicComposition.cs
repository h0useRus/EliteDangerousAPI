using Newtonsoft.Json;

namespace NSW.EliteDangerous.API
{
    public class GeologicComposition
    {
        [JsonProperty("Ice")]
        public double Ice { get; internal set; }

        [JsonProperty("Rock")]
        public double Rock { get; internal set; }

        [JsonProperty("Metal")]
        public double Metal { get; internal set; }
    }
}