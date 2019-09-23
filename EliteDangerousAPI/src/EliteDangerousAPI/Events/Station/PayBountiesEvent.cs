using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class PayBountiesEvent : JournalEvent
    {
        [JsonProperty("Amount")]
        public long Amount { get; internal set; }

        [JsonProperty("Faction")]
        public string Faction { get; internal set; }

        [JsonProperty("Faction_Localised")]
        public string FactionLocalised { get; internal set; }

        [JsonProperty("ShipID")]
        public long ShipId { get; internal set; }

        [JsonProperty("BrokerPercentage")]
        public double BrokerPercentage { get; internal set; }

        internal static PayBountiesEvent Execute(string json, API.EliteDangerousAPI api) => api.Station.InvokeEvent(api.FromJson<PayBountiesEvent>(json));
    }
}