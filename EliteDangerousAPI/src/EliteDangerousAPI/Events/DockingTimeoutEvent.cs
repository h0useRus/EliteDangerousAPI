namespace NSW.EliteDangerous.Events
{
    public class DockingTimeoutEvent : DockEvent
    {
        internal static DockingTimeoutEvent Execute(string json, API.EliteDangerousAPI api) => api.Travel.InvokeEvent(api.FromJson<DockingTimeoutEvent>(json));
    }
}