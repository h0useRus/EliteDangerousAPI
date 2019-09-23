using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class PowerplayFastTrackEvent : PowerplayEventBaseEvent
    {
        [JsonProperty("Cost")]
        public long Cost { get; internal set; }

        internal static PowerplayFastTrackEvent Execute(string json, API.EliteDangerousAPI api) => api.Powerplay.InvokeEvent(api.FromJson<PowerplayFastTrackEvent>(json));
    }
}