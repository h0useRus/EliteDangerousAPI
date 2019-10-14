using Newtonsoft.Json;
using NSW.EliteDangerous.API.Internals;

namespace NSW.EliteDangerous.API
{
    public class ShipyardPrice
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("ShipType")]
        public string ShipType { get; set; }

        [JsonIgnore] public ShipModel ShipModel => EnumHelper.GetShipModel(ShipType);

        [JsonProperty("ShipPrice")]
        public long ShipPrice { get; set; }

        [JsonProperty("ShipType_Localised", NullValueHandling = NullValueHandling.Ignore)]
        public string ShipTypeLocalised { get; set; }
    }
}