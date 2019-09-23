using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class CommunityGoalRewardEvent : CommunityGoalBaseEvent
    {
        [JsonProperty("Reward")]
        public long Reward { get; internal set; }

        internal static CommunityGoalRewardEvent Execute(string json, API.EliteDangerousAPI api) => api.Station.InvokeEvent(api.FromJson<CommunityGoalRewardEvent>(json));
    }
}