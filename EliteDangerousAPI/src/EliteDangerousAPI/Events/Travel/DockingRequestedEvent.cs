namespace NSW.EliteDangerous.API.Events
{
    public class DockingRequestedEvent : DockEvent
    {
        internal static DockingRequestedEvent Execute(string json, API.EliteDangerousAPI api) => api.TravelEvents.InvokeEvent(api.FromJson<DockingRequestedEvent>(json));
    }
}