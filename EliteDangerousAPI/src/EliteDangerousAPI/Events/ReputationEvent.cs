using NSW.EliteDangerous.Internals;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class ReputationEvent : JournalEvent
    {
        [JsonProperty("Empire")]
        public double Empire { get; internal set; }

        [JsonProperty("Federation")]
        public double Federation { get; internal set; }

        [JsonProperty("Alliance")]
        public double Alliance { get; internal set; }

        [JsonProperty("Independent")]
        public double? Independent { get; internal set; }

        internal static ReputationEvent Execute(string json, EliteDangerousAPI api) => api.Player.InvokeEvent(JsonHelper.FromJson<ReputationEvent>(json));
    }
}