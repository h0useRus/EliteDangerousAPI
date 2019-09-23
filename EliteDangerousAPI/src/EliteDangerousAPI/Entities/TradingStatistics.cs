using Newtonsoft.Json;

namespace NSW.EliteDangerous.API
{
    public class TradingStatistics
    {
        [JsonProperty("Markets_Traded_With")]
        public long MarketsTradedWith { get; internal set; }

        [JsonProperty("Market_Profits")]
        public long MarketProfits { get; internal set; }

        [JsonProperty("Resources_Traded")]
        public long ResourcesTraded { get; internal set; }

        [JsonProperty("Average_Profit")]
        public double AverageProfit { get; internal set; }

        [JsonProperty("Highest_Single_Transaction")]
        public long HighestSingleTransaction { get; internal set; }
    }
}