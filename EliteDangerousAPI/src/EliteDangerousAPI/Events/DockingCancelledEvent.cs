using NSW.EliteDangerous.Internals;

namespace NSW.EliteDangerous.Events
{
    public class DockingCancelledEvent : DockEvent
    {
        internal static DockingCancelledEvent Execute(string json, EliteDangerousAPI api) => api.Travel.InvokeEvent(JsonHelper.FromJson<DockingCancelledEvent>(json));
    }
}