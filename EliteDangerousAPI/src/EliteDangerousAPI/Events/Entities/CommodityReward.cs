using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events.Entities
{
    public class CommodityReward
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Name_Localised")]
        public string NameLocalised { get; set; }

        [JsonProperty("Count")]
        public long Count { get; set; }
    }
}