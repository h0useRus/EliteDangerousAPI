using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class PayFinesEvent : JournalEvent
    {
        [JsonProperty("Amount")]
        public long Amount { get; internal set; }

        [JsonProperty("AllFines")]
        public bool AllFines { get; internal set; }

        [JsonProperty("Faction")]
        public string Faction { get; internal set; }

        [JsonProperty("ShipID")]
        public long ShipId { get; internal set; }

        internal static PayFinesEvent Execute(string json, API.EliteDangerousAPI api) => api.Station.InvokeEvent(api.FromJson<PayFinesEvent>(json));
    }
}