using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
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

        internal static PowerplayEvent Execute(string json, API.EliteDangerousAPI api) => api.Powerplay.InvokeEvent(api.FromJson<PowerplayEvent>(json));
    }
}