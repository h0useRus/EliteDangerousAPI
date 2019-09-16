using NSW.EliteDangerous.Internals;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class PowerplayFastTrackEvent : PowerplayEventBaseEvent
    {
        [JsonProperty("Cost")]
        public long Cost { get; internal set; }

        internal static PowerplayFastTrackEvent Execute(string json, EliteDangerousAPI api) => api.Powerplay.InvokeEvent(JsonHelper.FromJson<PowerplayFastTrackEvent>(json));
    }
}