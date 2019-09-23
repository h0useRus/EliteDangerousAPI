using Newtonsoft.Json;

namespace NSW.EliteDangerous.API
{
    public class FactionVoucher
    {
        [JsonProperty("Faction")]
        public string Faction { get; internal set; }

        [JsonProperty("Amount")]
        public long Amount { get; internal set; }
    }
}