namespace NSW.EliteDangerous.API.Events
{
    public class DockingTimeoutEvent : DockEvent
    {
        internal static DockingTimeoutEvent Execute(string json, API.EliteDangerousAPI api) => api.TravelEvents.InvokeEvent(api.FromJson<DockingTimeoutEvent>(json));
    }
}