using NSW.EliteDangerous.Internals;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class PayLegacyFinesEvent : JournalEvent
    {
        [JsonProperty("Amount")]
        public long Amount { get; internal set; }

        [JsonProperty("BrokerPercentage")]
        public double BrokerPercentage { get; internal set; }

        internal static PayLegacyFinesEvent Execute(string json, EliteDangerousAPI api) => api.Station.InvokeEvent(JsonHelper.FromJson<PayLegacyFinesEvent>(json));
    }
}