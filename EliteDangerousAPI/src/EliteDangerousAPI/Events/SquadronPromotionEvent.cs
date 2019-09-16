using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class SquadronPromotionEvent : SquadronEvent
    {
        [JsonProperty("OldRank")]
        public int OldRank { get; internal set; }

        [JsonProperty("NewRank")]
        public int NewRank { get; internal set; }

        internal static SquadronPromotionEvent Execute(string json, EliteDangerousAPI api) => api.Squadron.InvokeEvent(api.FromJson<SquadronPromotionEvent>(json));
    }
}