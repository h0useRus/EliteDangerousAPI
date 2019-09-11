using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events.Entities
{
    public class Material : Item
    {
        [JsonProperty("Count")]
        public long Count { get; internal set; }
    }
}