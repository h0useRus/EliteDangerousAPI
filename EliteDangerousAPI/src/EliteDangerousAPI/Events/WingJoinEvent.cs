using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class WingJoinEvent : JournalEvent
    {
        [JsonProperty("Others")]
        public string[] Others { get; internal set; }

        internal static WingJoinEvent Execute(string json, API.EliteDangerousAPI api) => api.Wing.InvokeEvent(api.FromJson<WingJoinEvent>(json));
    }
}