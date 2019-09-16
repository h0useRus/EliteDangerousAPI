namespace NSW.EliteDangerous.Events
{
    public class DockingRequestedEvent : DockEvent
    {
        internal static DockingRequestedEvent Execute(string json, EliteDangerousAPI api) => api.Travel.InvokeEvent(api.FromJson<DockingRequestedEvent>(json));
    }
}