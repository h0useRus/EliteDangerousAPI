using NSW.EliteDangerous.Internals;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class CommunityGoalDiscardEvent : CommunityGoalBaseEvent
    {
        internal static CommunityGoalDiscardEvent Execute(string json, EliteDangerousAPI api) => api.Station.InvokeEvent(JsonHelper.FromJson<CommunityGoalDiscardEvent>(json));
    }
}