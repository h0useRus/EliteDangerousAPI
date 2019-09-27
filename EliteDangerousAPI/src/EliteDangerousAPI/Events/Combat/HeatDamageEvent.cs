namespace NSW.EliteDangerous.API.Events
{
    public class HeatDamageEvent : JournalEvent
    {
        internal static HeatDamageEvent Execute(string json, API.EliteDangerousAPI api) => api.CombatEvents.InvokeEvent(api.FromJson<HeatDamageEvent>(json));
    }
}