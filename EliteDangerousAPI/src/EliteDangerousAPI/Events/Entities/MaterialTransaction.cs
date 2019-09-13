using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events.Entities
{
    public class MaterialTransaction
    {
        [JsonProperty("Material")]
        public string Material { get; internal set; }

        [JsonProperty("Material_Localised")]
        public string MaterialLocalised { get; internal set; }

        [JsonProperty("Category")]
        public string Category { get; internal set; }

        [JsonProperty("Category_Localised")]
        public string CategoryLocalised { get; internal set; }

        [JsonProperty("Quantity")]
        public int Quantity { get; internal set; }
    }
}