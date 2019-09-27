namespace NSW.EliteDangerous.API.Events
{
    public class CommunityGoalDiscardEvent : CommunityGoalBaseEvent
    {
        internal static CommunityGoalDiscardEvent Execute(string json, API.EliteDangerousAPI api) => api.StationEvents.InvokeEvent(api.FromJson<CommunityGoalDiscardEvent>(json));
    }
}