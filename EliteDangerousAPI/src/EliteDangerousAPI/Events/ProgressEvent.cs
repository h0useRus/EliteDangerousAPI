using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class ProgressEvent : JournalEvent
    {
        [JsonProperty("Combat")]
        public byte Combat { get; internal set; }

        [JsonProperty("Trade")]
        public byte Trade { get; internal set; }

        [JsonProperty("Explore")]
        public byte Explore { get; internal set; }

        [JsonProperty("Empire")]
        public byte Empire { get; internal set; }

        [JsonProperty("Federation")]
        public byte Federation { get; internal set; }

        [JsonProperty("CQC")]
        public byte Cqc { get; internal set; }

        internal static ProgressEvent Execute(string json, API.EliteDangerousAPI api) => api.Player.InvokeEvent(api.FromJson<ProgressEvent>(json));
    }
}