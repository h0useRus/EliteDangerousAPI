using NSW.EliteDangerous.Internals;

namespace NSW.EliteDangerous.Events
{
    public class SystemsShutdownEvent : JournalEvent
    {
        internal static SystemsShutdownEvent Execute(string json, EliteDangerousAPI api) => api.Ship.InvokeEvent(JsonHelper.FromJson<SystemsShutdownEvent>(json));
    }
}