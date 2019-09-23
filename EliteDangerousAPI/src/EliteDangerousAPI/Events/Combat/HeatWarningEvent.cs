namespace NSW.EliteDangerous.API.Events
{
    public class HeatWarningEvent : JournalEvent
    {
        internal static HeatWarningEvent Execute(string json, API.EliteDangerousAPI api) => api.Combat.InvokeEvent(api.FromJson<HeatWarningEvent>(json));
    }
}