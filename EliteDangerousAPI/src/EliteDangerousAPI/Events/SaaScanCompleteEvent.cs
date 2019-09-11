using NSW.EliteDangerous.Internals;
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
        public long ProbesUsed { get; internal set; }

        [JsonProperty("EfficiencyTarget")]
        public long EfficiencyTarget { get; internal set; }

        internal static SaaScanCompleteEvent Execute(string json, EliteDangerousAPI api) => api.Exploration.InvokeEvent(JsonHelper.FromJson<SaaScanCompleteEvent>(json));
    }
}