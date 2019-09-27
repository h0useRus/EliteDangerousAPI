using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class WingJoinEvent : JournalEvent
    {
        [JsonProperty("Others")]
        public string[] Others { get; internal set; }

        internal static WingJoinEvent Execute(string json, API.EliteDangerousAPI api) => api.WingEvents.InvokeEvent(api.FromJson<WingJoinEvent>(json));
    }
}