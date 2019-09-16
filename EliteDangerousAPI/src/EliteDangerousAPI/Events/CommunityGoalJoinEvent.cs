using NSW.EliteDangerous.Internals;

namespace NSW.EliteDangerous.Events
{
    public class CommunityGoalJoinEvent : CommunityGoalBaseEvent
    {
        internal static CommunityGoalJoinEvent Execute(string json, EliteDangerousAPI api) => api.Station.InvokeEvent(JsonHelper.FromJson<CommunityGoalJoinEvent>(json));
    }
}