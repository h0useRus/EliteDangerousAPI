using Newtonsoft.Json;

namespace NSW.EliteDangerous.API
{
    public class ItemDetails : Item
    {
        [JsonProperty("Slot")]
        public string Slot { get; internal set; }

        [JsonProperty("Hot")]
        public bool Hot { get; internal set; }

        [JsonProperty("EngineerModifications")]
        public string EngineerModifications { get; internal set; }

        [JsonProperty("Level")]
        public long Level { get; internal set; }

        [JsonProperty("Quality")]
        public double Quality { get; internal set; }
    }
}