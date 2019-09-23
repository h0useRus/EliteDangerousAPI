namespace NSW.EliteDangerous.Events
{
    public class CommunityGoalJoinEvent : CommunityGoalBaseEvent
    {
        internal static CommunityGoalJoinEvent Execute(string json, API.EliteDangerousAPI api) => api.Station.InvokeEvent(api.FromJson<CommunityGoalJoinEvent>(json));
    }
}