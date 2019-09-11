using NSW.EliteDangerous.Internals;

namespace NSW.EliteDangerous.Events
{
    public class DockSrvEvent : JournalEvent
    {
        internal static DockSrvEvent Execute(string json, EliteDangerousAPI api) => api.Ship.InvokeEvent(JsonHelper.FromJson<DockSrvEvent>(json));
    }
}