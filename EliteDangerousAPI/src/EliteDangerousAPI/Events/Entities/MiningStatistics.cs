using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events.Entities
{
    public class MiningStatistics
    {
        [JsonProperty("Mining_Profits")]
        public long MiningProfits { get; set; }

        [JsonProperty("Quantity_Mined")]
        public long QuantityMined { get; set; }

        [JsonProperty("Materials_Collected")]
        public long MaterialsCollected { get; set; }
    }
}