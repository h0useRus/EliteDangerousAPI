using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events.Entities
{
    public class ExplorationStatistics
    {
        [JsonProperty("Systems_Visited")]
        public long SystemsVisited { get; internal set; }

        [JsonProperty("Fuel_Scooped")]
        public long FuelScooped { get; internal set; }

        [JsonProperty("Fuel_Purchased")]
        public long FuelPurchased { get; internal set; }

        [JsonProperty("Exploration_Profits")]
        public long ExplorationProfits { get; internal set; }

        [JsonProperty("Planets_Scanned_To_Level_2")]
        public long PlanetsScannedToLevel2 { get; internal set; }

        [JsonProperty("Planets_Scanned_To_Level_3")]
        public long PlanetsScannedToLevel3 { get; internal set; }

        [JsonProperty("Efficient_Scans")]
        public long? EfficientScans { get; internal set; }

        [JsonProperty("Highest_Payout")]
        public long HighestPayout { get; internal set; }

        [JsonProperty("Total_Hyperspace_Distance")]
        public long TotalHyperspaceDistance { get; internal set; }

        [JsonProperty("Total_Hyperspace_Jumps")]
        public long TotalHyperspaceJumps { get; internal set; }

        [JsonProperty("Greatest_Distance_From_Start")]
        public double GreatestDistanceFromStart { get; internal set; }

        [JsonProperty("Time_Played")]
        public long TimePlayed { get; internal set; }
    }
}