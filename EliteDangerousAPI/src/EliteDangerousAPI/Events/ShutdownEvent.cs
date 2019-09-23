namespace NSW.EliteDangerous.Events
{
    public class ShutdownEvent : JournalEvent
    {
        internal static ShutdownEvent Execute(string json, API.EliteDangerousAPI api) => api.Game.InvokeEvent(api.FromJson<ShutdownEvent>(json));
    }
}