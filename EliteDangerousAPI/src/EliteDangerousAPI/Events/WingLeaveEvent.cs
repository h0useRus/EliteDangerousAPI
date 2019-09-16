namespace NSW.EliteDangerous.Events
{
    public class WingLeaveEvent : JournalEvent
    {
        internal static WingLeaveEvent Execute(string json, EliteDangerousAPI api) => api.Wing.InvokeEvent(api.FromJson<WingLeaveEvent>(json));
    }
}