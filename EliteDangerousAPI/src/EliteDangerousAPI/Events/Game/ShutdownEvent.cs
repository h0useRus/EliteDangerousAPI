namespace NSW.EliteDangerous.API.Events
{
    public class ShutdownEvent : JournalEvent
    {
        internal static ShutdownEvent Execute(string json, API.EliteDangerousAPI api) => api.GameEvents.InvokeEvent(api.FromJson<ShutdownEvent>(json));
    }
}