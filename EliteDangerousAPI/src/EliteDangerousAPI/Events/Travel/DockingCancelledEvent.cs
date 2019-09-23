namespace NSW.EliteDangerous.API.Events
{
    public class DockingCancelledEvent : DockEvent
    {
        internal static DockingCancelledEvent Execute(string json, API.EliteDangerousAPI api) => api.Travel.InvokeEvent(api.FromJson<DockingCancelledEvent>(json));
    }
}