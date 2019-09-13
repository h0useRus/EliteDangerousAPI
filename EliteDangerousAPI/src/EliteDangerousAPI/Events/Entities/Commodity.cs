using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events.Entities
{
    public class Commodity : Material
    {
        [JsonProperty("Category")]
        public MaterialCategory Category { get; internal set; }
    }
}