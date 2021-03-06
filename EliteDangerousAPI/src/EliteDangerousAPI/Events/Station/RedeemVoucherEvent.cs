using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class RedeemVoucherEvent : JournalEvent
    {
        [JsonProperty("Type")]
        public VoucherType Type { get; internal set; }

        [JsonProperty("Faction")]
        public string Faction { get; internal set; }

        [JsonProperty("Amount")]
        public long Amount { get; internal set; }

        [JsonProperty("Factions")]
        public FactionVoucher[] Factions { get; internal set; }

        [JsonProperty("BrokerPercentage")]
        public double BrokerPercentage { get; internal set; }

        internal static RedeemVoucherEvent Execute(string json, API.EliteDangerousAPI api) => api.StationEvents.InvokeEvent(api.FromJson<RedeemVoucherEvent>(json));
    }
}