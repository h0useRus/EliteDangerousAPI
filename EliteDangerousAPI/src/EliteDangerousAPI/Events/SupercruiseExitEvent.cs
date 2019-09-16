using NSW.EliteDangerous.Events.Entities;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class SupercruiseExitEvent : JournalEvent
    {
        [JsonProperty("StarSystem")]
        public string StarSystem { get; internal set; }

        [JsonProperty("SystemAddress")]
        public long SystemAddress { get; internal set; }

        [JsonProperty("Body")]
        public string Body { get; internal set; }

        [JsonProperty("BodyID")]
        public long BodyId { get; internal set; }

        [JsonProperty("BodyType")]
        public BodyType? BodyType { get; internal set; }

        internal static SupercruiseExitEvent Execute(string json, EliteDangerousAPI api) => api.Travel.InvokeEvent(api.FromJson<SupercruiseExitEvent>(json));
    }
}