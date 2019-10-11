using Newtonsoft.Json;
using NSW.EliteDangerous.API.Internals;

namespace NSW.EliteDangerous.API
{
    public class StationEconomy
    {
        [JsonIgnore]public EconomyType Type => EnumHelper.GetEconomyType(Name);

        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("Name_Localised")]
        public string NameLocalised { get; internal set; }

        [JsonProperty("Proportion")]
        public double Proportion { get; internal set; }
    }
}