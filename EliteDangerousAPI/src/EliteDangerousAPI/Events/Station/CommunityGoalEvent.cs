using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class CommunityGoalEvent : JournalEvent
    {
        [JsonProperty("CurrentGoals")]
        public CommunityGoal[] CurrentGoals { get; internal set; }

        internal static CommunityGoalEvent Execute(string json, API.EliteDangerousAPI api) => api.StationEvents.InvokeEvent(api.FromJson<CommunityGoalEvent>(json));
    }
}