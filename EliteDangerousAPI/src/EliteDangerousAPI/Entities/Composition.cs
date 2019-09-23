using Newtonsoft.Json;

namespace NSW.EliteDangerous.API
{
    public class Composition : Item
    {
        [JsonProperty("Percent")]
        public double Percent { get; internal set; }
    }
}