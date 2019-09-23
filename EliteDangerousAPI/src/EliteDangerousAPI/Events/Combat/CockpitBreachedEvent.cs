namespace NSW.EliteDangerous.API.Events
{
    public class CockpitBreachedEvent : JournalEvent
    {
        internal static CockpitBreachedEvent Execute(string json, API.EliteDangerousAPI api) => api.Combat.InvokeEvent(api.FromJson<CockpitBreachedEvent>(json));
    }
}