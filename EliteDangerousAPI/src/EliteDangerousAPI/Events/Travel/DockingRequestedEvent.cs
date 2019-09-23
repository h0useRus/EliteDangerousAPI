namespace NSW.EliteDangerous.API.Events
{
    public class DockingRequestedEvent : DockEvent
    {
        internal static DockingRequestedEvent Execute(string json, API.EliteDangerousAPI api) => api.Travel.InvokeEvent(api.FromJson<DockingRequestedEvent>(json));
    }
}