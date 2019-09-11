using NSW.EliteDangerous.Internals;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class PowerplayFastTrackEvent : JournalEvent
    {
        [JsonProperty("Power")]
        public string Power { get; internal set; }

        [JsonProperty("Cost")]
        public long Cost { get; internal set; }

        internal static PowerplayFastTrackEvent Execute(string json, EliteDangerousAPI api) => api.Powerplay.InvokeEvent(JsonHelper.FromJson<PowerplayFastTrackEvent>(json));
    }
}