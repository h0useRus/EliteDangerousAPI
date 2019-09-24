using Newtonsoft.Json;

namespace NSW.EliteDangerous.API
{
    public class SurfaceSignal
    {
        [JsonProperty("Type")]
        public string Type { get; internal set; }

        [JsonProperty("Type_Localised")]
        public string TypeLocalised { get; internal set; }

        [JsonProperty("Count")]
        public int Count { get; internal set; }
    }
}