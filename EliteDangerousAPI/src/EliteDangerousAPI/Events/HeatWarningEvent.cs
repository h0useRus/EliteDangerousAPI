using NSW.EliteDangerous.Internals;

namespace NSW.EliteDangerous.Events
{
    public class HeatWarningEvent : JournalEvent
    {
        internal static HeatWarningEvent Execute(string json, EliteDangerousAPI api) => api.Combat.InvokeEvent(JsonHelper.FromJson<HeatWarningEvent>(json));
    }
}