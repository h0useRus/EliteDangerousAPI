using Newtonsoft.Json;

namespace NSW.EliteDangerous.API
{
    public class MaterialsReward : Material
    {
        [JsonProperty("Category")]
        public string Category { get; set; }

        [JsonProperty("Category_Localised")]
        public string CategoryLocalised { get; set; }
    }
}