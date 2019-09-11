using NSW.EliteDangerous.Internals;

namespace NSW.EliteDangerous.Events
{
    public class WingLeaveEvent : JournalEvent
    {
        internal static WingLeaveEvent Execute(string json, EliteDangerousAPI api) => api.Wing.InvokeEvent(JsonHelper.FromJson<WingLeaveEvent>(json));
    }
}