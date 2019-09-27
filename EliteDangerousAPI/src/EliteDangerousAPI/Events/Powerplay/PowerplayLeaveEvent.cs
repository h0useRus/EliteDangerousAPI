namespace NSW.EliteDangerous.API.Events
{
    public class PowerplayLeaveEvent : PowerplayEventBaseEvent
    {
        internal static PowerplayLeaveEvent Execute(string json, API.EliteDangerousAPI api) => api.PowerplayEvents.InvokeEvent(api.FromJson<PowerplayLeaveEvent>(json));
    }
}