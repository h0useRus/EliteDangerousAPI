using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events.Entities
{
    public class ShipStoredRemote : ShipStored
    {
        [JsonProperty("StarSystem")]
        public string StarSystem { get; set; }

        [JsonProperty("ShipMarketID")]
        public long ShipMarketId { get; set; }

        [JsonProperty("TransferPrice")]
        public long TransferPrice { get; set; }

        [JsonProperty("TransferTime")]
        public long TransferTime { get; set; }
    }
}