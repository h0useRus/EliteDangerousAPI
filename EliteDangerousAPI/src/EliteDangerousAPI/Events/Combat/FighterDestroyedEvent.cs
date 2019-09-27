namespace NSW.EliteDangerous.API.Events
{
    public class FighterDestroyedEvent : JournalEvent
    {
        internal static FighterDestroyedEvent Execute(string json, API.EliteDangerousAPI api) => api.CombatEvents.InvokeEvent(api.FromJson<FighterDestroyedEvent>(json));
    }
}