using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events.Entities
{
    public class Killer
    {
        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("Ship")]
        public string Ship { get; internal set; }

        [JsonProperty("Rank")]
        public string Rank { get; internal set; }
    }
}