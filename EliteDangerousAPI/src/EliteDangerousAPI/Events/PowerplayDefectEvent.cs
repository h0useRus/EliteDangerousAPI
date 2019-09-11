using NSW.EliteDangerous.Internals;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class PowerplayDefectEvent : JournalEvent
    {
        [JsonProperty]
        public string FromPower { get; internal set; }

        [JsonProperty]
        public string ToPower { get; internal set; }

        internal static PowerplayDefectEvent Execute(string json, EliteDangerousAPI api) => api.Powerplay.InvokeEvent(JsonHelper.FromJson<PowerplayDefectEvent>(json));
    }
}