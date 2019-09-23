using Newtonsoft.Json;

namespace NSW.EliteDangerous.API
{
    public class StoredItem : Item
    {
        [JsonProperty("StorageSlot")]
        public long StorageSlot { get; set; }

        [JsonProperty("StarSystem")]
        public string StarSystem { get; set; }

        [JsonProperty("MarketID")]
        public long MarketId { get; set; }

        [JsonProperty("TransferCost")]
        public long TransferCost { get; set; }

        [JsonProperty("TransferTime")]
        public long TransferTime { get; set; }

        [JsonProperty("BuyPrice")]
        public long BuyPrice { get; set; }

        [JsonProperty("Hot")]
        public bool Hot { get; set; }

        [JsonProperty("EngineerModifications")]
        public string EngineerModifications { get; set; }

        [JsonProperty("Level")]
        public short Level { get; set; }

        [JsonProperty("Quality")]
        public double Quality { get; set; }
    }
}