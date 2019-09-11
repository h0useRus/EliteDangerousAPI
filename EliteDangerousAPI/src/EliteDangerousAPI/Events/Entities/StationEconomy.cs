using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events.Entities
{
    public class StationEconomy
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Name_Localised")]
        public string NameLocalised { get; set; }

        [JsonProperty("Proportion")]
        public double Proportion { get; set; }
    }
}