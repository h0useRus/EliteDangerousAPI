using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events.Entities
{
    public class OutfittingItem
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("BuyPrice")]
        public long BuyPrice { get; set; }
    }
}