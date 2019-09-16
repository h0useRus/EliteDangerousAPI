using NSW.EliteDangerous.Internals;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class WingInviteEvent : JournalEvent
    {
        [JsonProperty("Name")]
        public string Name { get; internal set; }

        internal static WingInviteEvent Execute(string json, EliteDangerousAPI api) => api.Wing.InvokeEvent(JsonHelper.FromJson<WingInviteEvent>(json));
    }
}