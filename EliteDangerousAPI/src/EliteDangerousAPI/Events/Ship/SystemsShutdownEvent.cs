namespace NSW.EliteDangerous.API.Events
{
    public class SystemsShutdownEvent : JournalEvent
    {
        internal static SystemsShutdownEvent Execute(string json, API.EliteDangerousAPI api) => api.ShipEvents.InvokeEvent(api.FromJson<SystemsShutdownEvent>(json));
    }
}