using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class DatalinkVoucherEvent : JournalEvent
    {
        [JsonProperty("Reward")]
        public long Reward { get; internal set; }

        [JsonProperty("VictimFaction")]
        public string VictimFaction { get; internal set; }

        [JsonProperty("PayeeFaction")]
        public string PayeeFaction { get; internal set; }

        internal static DatalinkVoucherEvent Execute(string json, API.EliteDangerousAPI api) => api.ExplorationEvents.InvokeEvent(api.FromJson<DatalinkVoucherEvent>(json));
    }
}