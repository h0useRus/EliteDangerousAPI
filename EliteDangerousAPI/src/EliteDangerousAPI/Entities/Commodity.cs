using Newtonsoft.Json;

namespace NSW.EliteDangerous.API
{
    public class Commodity : Material
    {
        [JsonProperty("Category")]
        public MaterialCategory Category { get; internal set; }
    }
}