namespace NSW.EliteDangerous.Events
{
    public class CockpitBreachedEvent : JournalEvent
    {
        internal static CockpitBreachedEvent Execute(string json, EliteDangerousAPI api) => api.Combat.InvokeEvent(api.FromJson<CockpitBreachedEvent>(json));
    }
}