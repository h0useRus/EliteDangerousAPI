namespace NSW.EliteDangerous.Events
{
    public class PowerplayLeaveEvent : PowerplayEventBaseEvent
    {
        internal static PowerplayLeaveEvent Execute(string json, API.EliteDangerousAPI api) => api.Powerplay.InvokeEvent(api.FromJson<PowerplayLeaveEvent>(json));
    }
}