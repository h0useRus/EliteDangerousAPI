using NSW.EliteDangerous.Internals;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class DatalinkVoucherEvent : JournalEvent
    {
        [JsonProperty("Reward")]
        public long Reward { get; internal set; }

        [JsonProperty("VictimFaction")]
        public string VictimFaction { get; internal set; }

        [JsonProperty("PayeeFaction")]
        public string PayeeFaction { get; internal set; }

        internal static DatalinkVoucherEvent Execute(string json, EliteDangerousAPI api) => api.Exploration.InvokeEvent(JsonHelper.FromJson<DatalinkVoucherEvent>(json));
    }
}