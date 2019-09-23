using Newtonsoft.Json;

namespace NSW.EliteDangerous.API
{
    public class EngineerProgress
    {
        [JsonProperty("Engineer")]
        public string EngineerName { get; internal set; }

        [JsonProperty("EngineerID")]
        public int EngineerId { get; internal set; }

        [JsonProperty("Progress")]
        public EngineerProgressState Progress { get; internal set; }

        [JsonProperty("RankProgress", NullValueHandling = NullValueHandling.Ignore)]
        public int? RankProgress { get; internal set; }

        [JsonProperty("Rank", NullValueHandling = NullValueHandling.Ignore)]
        public int? Rank { get; internal set; }
    }
}