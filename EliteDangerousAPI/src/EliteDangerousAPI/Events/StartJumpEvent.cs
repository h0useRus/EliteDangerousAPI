using Newtonsoft.Json;
using NSW.EliteDangerous.Events.Entities;

namespace NSW.EliteDangerous.Events
{
    public class StartJumpEvent : JournalEvent
    {
        [JsonProperty("JumpType")]
        public JumpType JumpType { get; internal set; }

        [JsonProperty("StarSystem")]
        public string StarSystem { get; internal set; }

        [JsonProperty("SystemAddress")]
        public long SystemAddress { get; internal set; }

        [JsonProperty("StarClass")]
        public string StarClass { get; internal set; }

        internal static StartJumpEvent Execute(string json, API.EliteDangerousAPI api) => api.Travel.InvokeEvent(api.FromJson<StartJumpEvent>(json));
    }
}