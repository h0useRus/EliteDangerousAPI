namespace NSW.EliteDangerous.API.Events
{
    public class WingLeaveEvent : JournalEvent
    {
        internal static WingLeaveEvent Execute(string json, API.EliteDangerousAPI api) => api.Wing.InvokeEvent(api.FromJson<WingLeaveEvent>(json));
    }
}