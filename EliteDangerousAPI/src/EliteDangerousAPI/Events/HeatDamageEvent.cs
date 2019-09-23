namespace NSW.EliteDangerous.Events
{
    public class HeatDamageEvent : JournalEvent
    {
        internal static HeatDamageEvent Execute(string json, API.EliteDangerousAPI api) => api.Combat.InvokeEvent(api.FromJson<HeatDamageEvent>(json));
    }
}