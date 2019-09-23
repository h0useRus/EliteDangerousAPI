using Newtonsoft.Json;

namespace NSW.EliteDangerous.API
{
    public class ShipStoredRemote : ShipStored
    {
        [JsonProperty("StarSystem")]
        public string StarSystem { get; internal set; }

        [JsonProperty("ShipMarketID")]
        public long ShipMarketId { get; internal set; }

        [JsonProperty("TransferPrice")]
        public long TransferPrice { get; internal set; }

        [JsonProperty("TransferTime")]
        public long TransferTime { get; internal set; }
    }
}