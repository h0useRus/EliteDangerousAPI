using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class MissionsEvent : JournalEvent
    {
        [JsonProperty("Active")]
        public Mission[] Active { get; internal set; }

        [JsonProperty("Failed")]
        public Mission[] Failed { get; internal set; }

        [JsonProperty("Complete")]
        public Mission[] Complete { get; internal set; }

        internal static MissionsEvent Execute(string json, API.EliteDangerousAPI api) => api.PlayerEvents.InvokeEvent(api.FromJson<MissionsEvent>(json));
    }
}