using Newtonsoft.Json;

namespace NSW.EliteDangerous.API
{
    public class ParentBody
    {
        [JsonProperty("Star")]
        public byte? Star { get; internal set; }

        [JsonProperty("Planet")]
        public byte? Planet { get; internal set; }

        [JsonProperty("Null")]
        public byte? Null { get; internal set; }
    }
}