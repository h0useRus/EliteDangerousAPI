namespace NSW.EliteDangerous.API.Events
{
    public class PowerplayJoinEvent : PowerplayEventBaseEvent
    {
        internal static PowerplayJoinEvent Execute(string json, API.EliteDangerousAPI api) => api.PowerplayEvents.InvokeEvent(api.FromJson<PowerplayJoinEvent>(json));
    }
}