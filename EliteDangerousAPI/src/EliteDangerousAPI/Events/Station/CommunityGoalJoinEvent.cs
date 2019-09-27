namespace NSW.EliteDangerous.API.Events
{
    public class CommunityGoalJoinEvent : CommunityGoalBaseEvent
    {
        internal static CommunityGoalJoinEvent Execute(string json, API.EliteDangerousAPI api) => api.StationEvents.InvokeEvent(api.FromJson<CommunityGoalJoinEvent>(json));
    }
}