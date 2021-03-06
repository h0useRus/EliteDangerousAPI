using Newtonsoft.Json;

namespace NSW.EliteDangerous.API
{
    public class ConflictFaction
    {
        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("Stake")]
        public string Stake { get; internal set; }

        [JsonProperty("WonDays")]
        public int WonDays { get; internal set; }
    }
}