namespace NSW.EliteDangerous.Events
{
    public class FighterDestroyedEvent : JournalEvent
    {
        internal static FighterDestroyedEvent Execute(string json, API.EliteDangerousAPI api) => api.Combat.InvokeEvent(api.FromJson<FighterDestroyedEvent>(json));
    }
}