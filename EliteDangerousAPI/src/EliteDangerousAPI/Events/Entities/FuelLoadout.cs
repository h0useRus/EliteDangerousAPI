using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events.Entities
{
    public class FuelLoadout
    {
        [JsonProperty("Main")]
        public double Main { get; internal set; }

        [JsonProperty("Reserve")]
        public double Reserve { get; internal set; }
    }
}