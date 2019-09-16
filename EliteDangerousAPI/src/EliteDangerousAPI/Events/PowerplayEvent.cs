using NSW.EliteDangerous.Internals;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class PowerplayEvent : PowerplayEventBaseEvent
    {
        [JsonProperty]
        public int Rank { get; internal set; }

        [JsonProperty]
        public int? Merits { get; internal set; }

        [JsonProperty]
        public int? Votes { get; internal set; }

        [JsonProperty]
        public int? TimePledged { get; internal set; }

        internal static PowerplayEvent Execute(string json, EliteDangerousAPI api) => api.Powerplay.InvokeEvent(JsonHelper.FromJson<PowerplayEvent>(json));
    }
}