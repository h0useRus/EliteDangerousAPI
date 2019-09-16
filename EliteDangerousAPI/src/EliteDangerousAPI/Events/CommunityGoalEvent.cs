using NSW.EliteDangerous.Events.Entities;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class CommunityGoalEvent : JournalEvent
    {
        [JsonProperty("CurrentGoals")]
        public CommunityGoal[] CurrentGoals { get; internal set; }

        internal static CommunityGoalEvent Execute(string json, EliteDangerousAPI api) => api.Station.InvokeEvent(api.FromJson<CommunityGoalEvent>(json));
    }
}