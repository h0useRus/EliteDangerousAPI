namespace NSW.EliteDangerous.Events
{
    public class PowerplayLeaveEvent : PowerplayEventBaseEvent
    {
        internal static PowerplayLeaveEvent Execute(string json, EliteDangerousAPI api) => api.Powerplay.InvokeEvent(api.FromJson<PowerplayLeaveEvent>(json));
    }
}