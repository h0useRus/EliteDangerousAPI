using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events.Entities
{
    public class Fuel
    {
        [JsonProperty("FuelMain")]
        public double FuelMain { get; internal set; }

        [JsonProperty("FuelReservoir")]
        public double FuelReservoir { get; internal set; }

        [JsonProperty("MaxFuel")]
        public double MaxFuel { get; internal set; }
    }
}