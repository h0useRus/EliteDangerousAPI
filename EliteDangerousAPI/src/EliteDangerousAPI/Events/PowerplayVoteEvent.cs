using NSW.EliteDangerous.Internals;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class PowerplayVoteEvent : PowerplayEventBaseEvent
    {
        [JsonProperty("Votes")]
        public long Votes { get; internal set; }

        [JsonProperty("VoteToConsolidate")]
        public long VoteToConsolidate { get; internal set; }

        [JsonProperty("System")]
        public string System { get; internal set; }

        internal static PowerplayVoteEvent Execute(string json, EliteDangerousAPI api) => api.Powerplay.InvokeEvent(JsonHelper.FromJson<PowerplayVoteEvent>(json));
    }
}