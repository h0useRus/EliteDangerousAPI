namespace NSW.EliteDangerous.Events
{
    public class SystemsShutdownEvent : JournalEvent
    {
        internal static SystemsShutdownEvent Execute(string json, EliteDangerousAPI api) => api.Ship.InvokeEvent(api.FromJson<SystemsShutdownEvent>(json));
    }
}