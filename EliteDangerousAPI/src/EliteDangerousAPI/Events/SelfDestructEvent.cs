using NSW.EliteDangerous.Internals;

namespace NSW.EliteDangerous.Events
{
    public class SelfDestructEvent : JournalEvent
    {
        internal static SelfDestructEvent Execute(string json, EliteDangerousAPI api) => api.Ship.InvokeEvent(JsonHelper.FromJson<SelfDestructEvent>(json));
    }
}