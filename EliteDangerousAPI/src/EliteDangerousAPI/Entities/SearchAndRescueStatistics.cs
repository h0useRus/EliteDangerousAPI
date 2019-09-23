using Newtonsoft.Json;

namespace NSW.EliteDangerous.API
{
    public class SearchAndRescueStatistics
    {
        [JsonProperty("SearchRescue_Traded")]
        public long Traded { get; internal set; }

        [JsonProperty("SearchRescue_Profit")]
        public long Profit { get; internal set; }

        [JsonProperty("SearchRescue_Count")]
        public long Count { get; internal set; }
    }
}