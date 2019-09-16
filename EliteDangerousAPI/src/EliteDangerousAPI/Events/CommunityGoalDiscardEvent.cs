using NSW.EliteDangerous.Internals;

namespace NSW.EliteDangerous.Events
{
    public class CommunityGoalDiscardEvent : CommunityGoalBaseEvent
    {
        internal static CommunityGoalDiscardEvent Execute(string json, EliteDangerousAPI api) => api.Station.InvokeEvent(JsonHelper.FromJson<CommunityGoalDiscardEvent>(json));
    }
}