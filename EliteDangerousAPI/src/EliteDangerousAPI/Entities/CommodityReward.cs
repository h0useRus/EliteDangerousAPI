using Newtonsoft.Json;

namespace NSW.EliteDangerous.API
{
    public class CommodityReward
    {
        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("Name_Localised")]
        public string NameLocalised { get; internal set; }

        [JsonProperty("Count")]
        public long Count { get; internal set; }
    }
}