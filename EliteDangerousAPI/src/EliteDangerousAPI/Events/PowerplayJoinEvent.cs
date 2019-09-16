using NSW.EliteDangerous.Internals;

namespace NSW.EliteDangerous.Events
{
    public class PowerplayJoinEvent : PowerplayEventBaseEvent
    {
        internal static PowerplayJoinEvent Execute(string json, EliteDangerousAPI api) => api.Powerplay.InvokeEvent(JsonHelper.FromJson<PowerplayJoinEvent>(json));
    }
}