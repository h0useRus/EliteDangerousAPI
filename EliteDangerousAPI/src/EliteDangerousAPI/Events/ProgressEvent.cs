using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class ProgressEvent : JournalEvent
    {
        [JsonProperty("Combat")]
        public int Combat { get; internal set; }

        [JsonProperty("Trade")]
        public int Trade { get; internal set; }

        [JsonProperty("Explore")]
        public int Explore { get; internal set; }

        [JsonProperty("Empire")]
        public int Empire { get; internal set; }

        [JsonProperty("Federation")]
        public int Federation { get; internal set; }

        [JsonProperty("CQC")]
        public int Cqc { get; internal set; }

        internal static ProgressEvent Execute(string json, EliteDangerousAPI api) => api.Player.InvokeEvent(api.FromJson<ProgressEvent>(json));
    }
}