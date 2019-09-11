using NSW.EliteDangerous.Internals;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class WingJoinEvent : JournalEvent
    {
        [JsonProperty("Others")]
        public string[] Others { get; internal set; }

        internal static WingJoinEvent Execute(string json, EliteDangerousAPI api) => api.Wing.InvokeEvent(JsonHelper.FromJson<WingJoinEvent>(json));
    }
}