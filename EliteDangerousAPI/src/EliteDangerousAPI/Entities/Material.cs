using Newtonsoft.Json;

namespace NSW.EliteDangerous.API
{
    public class Material : Item
    {
        [JsonProperty("Count")]
        public long Count { get; internal set; }
    }
}