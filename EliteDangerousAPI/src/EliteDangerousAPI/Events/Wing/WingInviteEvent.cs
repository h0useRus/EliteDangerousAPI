using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class WingInviteEvent : JournalEvent
    {
        [JsonProperty("Name")]
        public string Name { get; internal set; }

        internal static WingInviteEvent Execute(string json, API.EliteDangerousAPI api) => api.WingEvents.InvokeEvent(api.FromJson<WingInviteEvent>(json));
    }
}