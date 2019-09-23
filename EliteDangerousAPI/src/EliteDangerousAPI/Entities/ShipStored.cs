using Newtonsoft.Json;

namespace NSW.EliteDangerous.API
{
    public class ShipStored
    {
        [JsonProperty("ShipID")]
        public long ShipId { get; internal set; }

        [JsonProperty("ShipType")]
        public string ShipType { get; internal set; }

        [JsonProperty("ShipType_Localised", NullValueHandling = NullValueHandling.Ignore)]
        public string ShipTypeLocalised { get; internal set; }

        [JsonProperty("Value")]
        public long Value { get; internal set; }

        [JsonProperty("Hot")]
        public bool Hot { get; internal set; }

        [JsonProperty("Name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; internal set; }
    }
}