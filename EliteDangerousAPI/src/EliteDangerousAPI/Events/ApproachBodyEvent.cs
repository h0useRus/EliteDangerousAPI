using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class ApproachBodyEvent : JournalEvent
    {
        [JsonProperty("StarSystem")]
        public string StarSystem { get; internal set; }

        [JsonProperty("SystemAddress")]
        public long SystemAddress { get; internal set; }

        [JsonProperty("Body")]
        public string Body { get; internal set; }

        [JsonProperty("BodyID")]
        public long BodyId { get; internal set; }

        internal static ApproachBodyEvent Execute(string json, API.EliteDangerousAPI api) => api.Travel.InvokeEvent(api.FromJson<ApproachBodyEvent>(json));
    }
}