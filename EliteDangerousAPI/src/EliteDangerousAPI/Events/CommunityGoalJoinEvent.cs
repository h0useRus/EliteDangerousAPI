namespace NSW.EliteDangerous.Events
{
    public class CommunityGoalJoinEvent : CommunityGoalBaseEvent
    {
        internal static CommunityGoalJoinEvent Execute(string json, EliteDangerousAPI api) => api.Station.InvokeEvent(api.FromJson<CommunityGoalJoinEvent>(json));
    }
}