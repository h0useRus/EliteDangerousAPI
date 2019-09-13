using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events.Entities
{
    public class FactionVoucher
    {
        [JsonProperty("Faction")]
        public string Faction { get; internal set; }

        [JsonProperty("Amount")]
        public long Amount { get; internal set; }
    }
}