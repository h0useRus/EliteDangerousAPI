using NSW.EliteDangerous.Internals;

namespace NSW.EliteDangerous.Events
{
    public class DockingTimeoutEvent : DockEvent
    {
        internal static DockingTimeoutEvent Execute(string json, EliteDangerousAPI api) => api.Travel.InvokeEvent(JsonHelper.FromJson<DockingTimeoutEvent>(json));
    }
}