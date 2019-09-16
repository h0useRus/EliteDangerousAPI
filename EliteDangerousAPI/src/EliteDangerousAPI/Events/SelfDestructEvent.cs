namespace NSW.EliteDangerous.Events
{
    public class SelfDestructEvent : JournalEvent
    {
        internal static SelfDestructEvent Execute(string json, EliteDangerousAPI api) => api.Ship.InvokeEvent(api.FromJson<SelfDestructEvent>(json));
    }
}