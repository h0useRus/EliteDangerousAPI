using Newtonsoft.Json;

namespace NSW.EliteDangerous.API
{
    public class OutfittingItem : Item
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("BuyPrice")]
        public long BuyPrice { get; set; }
    }
}