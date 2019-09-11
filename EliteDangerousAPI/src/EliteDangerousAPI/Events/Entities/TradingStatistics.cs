﻿using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events.Entities
{
    public class TradingStatistics
    {
        [JsonProperty("Markets_Traded_With")]
        public long MarketsTradedWith { get; set; }

        [JsonProperty("Market_Profits")]
        public long MarketProfits { get; set; }

        [JsonProperty("Resources_Traded")]
        public long ResourcesTraded { get; set; }

        [JsonProperty("Average_Profit")]
        public double AverageProfit { get; set; }

        [JsonProperty("Highest_Single_Transaction")]
        public long HighestSingleTransaction { get; set; }
    }
}