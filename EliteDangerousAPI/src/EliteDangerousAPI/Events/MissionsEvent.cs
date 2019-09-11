using NSW.EliteDangerous.Events.Entities;
using Newtonsoft.Json;
using NSW.EliteDangerous.Internals;

namespace NSW.EliteDangerous.Events
{
    public class MissionsEvent : JournalEvent
    {
        [JsonProperty("Active")]
        public Mission[] Active { get; internal set; }

        [JsonProperty("Failed")]
        public Mission[] Failed { get; internal set; }

        [JsonProperty("Complete")]
        public Mission[] Complete { get; internal set; }

        internal static MissionsEvent Execute(string json, EliteDangerousAPI api) => api.Player.InvokeEvent(JsonHelper.FromJson<MissionsEvent>(json));
    }
}