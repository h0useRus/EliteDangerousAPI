using Newtonsoft.Json;

namespace NSW.EliteDangerous.API
{
    public class FuelLoadout
    {
        [JsonProperty("Main")]
        public double Main { get; internal set; }

        [JsonProperty("Reserve")]
        public double Reserve { get; internal set; }
    }
}