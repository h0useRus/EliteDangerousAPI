using Newtonsoft.Json;
using NSW.EliteDangerous.API;

namespace NSW.EliteDangerous.Events
{
    public class CommunityGoalEvent : JournalEvent
    {
        [JsonProperty("CurrentGoals")]
        public CommunityGoal[] CurrentGoals { get; internal set; }

        internal static CommunityGoalEvent Execute(string json, API.EliteDangerousAPI api) => api.Station.InvokeEvent(api.FromJson<CommunityGoalEvent>(json));
    }
}