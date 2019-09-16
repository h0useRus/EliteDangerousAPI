namespace NSW.EliteDangerous.Events
{
    public class ShutdownEvent : JournalEvent
    {
        internal static ShutdownEvent Execute(string json, EliteDangerousAPI api) => api.Game.InvokeEvent(api.FromJson<ShutdownEvent>(json));
    }
}