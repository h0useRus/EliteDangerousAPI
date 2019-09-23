using System;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.API
{
    public class CommunityGoal
    {
        [JsonProperty("CGID")]
        public long GoalId { get; internal set; }

        [JsonProperty("Title")]
        public string Title { get; internal set; }

        [JsonProperty("SystemName")]
        public string SystemName { get; internal set; }

        [JsonProperty("MarketName")]
        public string MarketName { get; internal set; }

        [JsonProperty("Expiry")]
        public DateTime Expiry { get; internal set; }

        [JsonProperty("IsComplete")]
        public bool IsComplete { get; internal set; }

        [JsonProperty("CurrentTotal")]
        public long CurrentTotal { get; internal set; }

        [JsonProperty("PlayerContribution")]
        public long PlayerContribution { get; internal set; }

        [JsonProperty("NumContributors")]
        public long NumContributors { get; internal set; }

        [JsonProperty("TopRankSize")]
        public long TopRankSize { get; internal set; }

        [JsonProperty("PlayerInTopRank")]
        public bool PlayerInTopRank { get; internal set; }

        [JsonProperty("TierReached")]
        public string TierReached { get; internal set; }

        [JsonProperty("PlayerPercentileBand")]
        public long PlayerPercentileBand { get; internal set; }

        [JsonProperty("Bonus")]
        public long Bonus { get; internal set; }

        [JsonProperty("TopTier")]
        public TopTier TopTier { get; internal set; }
    }
}