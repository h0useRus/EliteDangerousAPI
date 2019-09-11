using NSW.EliteDangerous.Internals;

namespace NSW.EliteDangerous.Events
{
    public class HeatDamageEvent : JournalEvent
    {
        internal static HeatDamageEvent Execute(string json, EliteDangerousAPI api) => api.Combat.InvokeEvent(JsonHelper.FromJson<HeatDamageEvent>(json));
    }
}