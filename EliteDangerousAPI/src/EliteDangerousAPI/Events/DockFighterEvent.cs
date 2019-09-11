using NSW.EliteDangerous.Internals;

namespace NSW.EliteDangerous.Events
{
    public class DockFighterEvent : JournalEvent
    {
        internal static DockFighterEvent Execute(string json, EliteDangerousAPI api) => api.Ship.InvokeEvent(JsonHelper.FromJson<DockFighterEvent>(json));
    }
}