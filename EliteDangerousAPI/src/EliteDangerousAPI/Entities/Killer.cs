using Newtonsoft.Json;
using NSW.EliteDangerous.API.Internals;

namespace NSW.EliteDangerous.API
{
    public class Killer
    {
        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("Ship")]
        public string ShipType { get; internal set; }

        [JsonIgnore] public ShipModel ShipModel => EnumHelper.GetShipModel(ShipType);

        [JsonProperty("Rank")]
        public CombatRank Rank { get; internal set; }
    }
}