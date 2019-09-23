using Newtonsoft.Json;

namespace NSW.EliteDangerous.API
{
    public class MarketItem : Item
    {
        [JsonProperty("id")]
        public long Id { get; internal set; }

        [JsonProperty("Category")]
        public string Category { get; internal set; }

        [JsonProperty("Category_Localised")]
        public string CategoryLocalised { get; internal set; }

        [JsonProperty("BuyPrice")]
        public long BuyPrice { get; internal set; }

        [JsonProperty("SellPrice")]
        public long SellPrice { get; internal set; }

        [JsonProperty("MeanPrice")]
        public long MeanPrice { get; internal set; }

        [JsonProperty("StockBracket")]
        public long StockBracket { get; internal set; }

        [JsonProperty("DemandBracket")]
        public long DemandBracket { get; internal set; }

        [JsonProperty("Stock")]
        public long Stock { get; internal set; }

        [JsonProperty("Demand")]
        public long Demand { get; internal set; }

        [JsonProperty("Consumer")]
        public bool Consumer { get; internal set; }

        [JsonProperty("Producer")]
        public bool Producer { get; internal set; }

        [JsonProperty("Rare")]
        public bool Rare { get; internal set; }

        [JsonProperty("Legality")]
        public string Legality { get; internal set; }
    }
}