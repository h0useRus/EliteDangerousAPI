using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class SaaScanCompleteEvent : JournalEvent
    {
        [JsonProperty("BodyName")]
        public string BodyName { get; internal set; }

        [JsonProperty("BodyID")]
        public long BodyId { get; internal set; }

        [JsonProperty("ProbesUsed")]
        public int ProbesUsed { get; internal set; }

        [JsonProperty("EfficiencyTarget")]
        public int EfficiencyTarget { get; internal set; }

        internal static SaaScanCompleteEvent Execute(string json, API.EliteDangerousAPI api) => api.Exploration.InvokeEvent(api.FromJson<SaaScanCompleteEvent>(json));
    }
}