using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class SquadronPromotionEvent : SquadronEvent
    {
        [JsonProperty("OldRank")]
        public SquadronRank OldRank { get; internal set; }

        [JsonProperty("NewRank")]
        public SquadronRank NewRank { get; internal set; }

        internal static SquadronPromotionEvent Execute(string json, API.EliteDangerousAPI api) => api.SquadronEvents.InvokeEvent(api.FromJson<SquadronPromotionEvent>(json));
    }
}