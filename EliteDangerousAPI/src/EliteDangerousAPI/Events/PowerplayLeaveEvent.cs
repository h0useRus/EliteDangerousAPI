using NSW.EliteDangerous.Internals;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class PowerplayLeaveEvent : PowerplayEventBaseEvent
    {
        internal static PowerplayLeaveEvent Execute(string json, EliteDangerousAPI api) => api.Powerplay.InvokeEvent(JsonHelper.FromJson<PowerplayLeaveEvent>(json));
    }
}