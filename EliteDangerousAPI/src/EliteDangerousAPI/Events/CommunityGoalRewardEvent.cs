using NSW.EliteDangerous.Internals;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class CommunityGoalRewardEvent : CommunityGoalBaseEvent
    {
        [JsonProperty("Reward")]
        public long Reward { get; internal set; }

        internal static CommunityGoalRewardEvent Execute(string json, EliteDangerousAPI api) => api.Station.InvokeEvent(JsonHelper.FromJson<CommunityGoalRewardEvent>(json));
    }
}