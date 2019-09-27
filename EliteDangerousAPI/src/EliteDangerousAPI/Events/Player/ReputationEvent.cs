using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
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
        public double Independent { get; internal set; }

        internal static ReputationEvent Execute(string json, API.EliteDangerousAPI api) => api.PlayerEvents.InvokeEvent(api.FromJson<ReputationEvent>(json));
    }
}