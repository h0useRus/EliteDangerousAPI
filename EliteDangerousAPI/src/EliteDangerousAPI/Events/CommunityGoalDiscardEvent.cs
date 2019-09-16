namespace NSW.EliteDangerous.Events
{
    public class CommunityGoalDiscardEvent : CommunityGoalBaseEvent
    {
        internal static CommunityGoalDiscardEvent Execute(string json, EliteDangerousAPI api) => api.Station.InvokeEvent(api.FromJson<CommunityGoalDiscardEvent>(json));
    }
}