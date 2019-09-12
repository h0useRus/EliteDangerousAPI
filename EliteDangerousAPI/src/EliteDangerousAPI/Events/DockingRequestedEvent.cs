using NSW.EliteDangerous.Internals;

namespace NSW.EliteDangerous.Events
{
    public class DockingRequestedEvent : DockEvent
    {
        internal static DockingRequestedEvent Execute(string json, EliteDangerousAPI api) => api.Travel.InvokeEvent(JsonHelper.FromJson<DockingRequestedEvent>(json));
    }
}