namespace NSW.EliteDangerous.Events
{
    public class PowerplayJoinEvent : PowerplayEventBaseEvent
    {
        internal static PowerplayJoinEvent Execute(string json, API.EliteDangerousAPI api) => api.Powerplay.InvokeEvent(api.FromJson<PowerplayJoinEvent>(json));
    }
}