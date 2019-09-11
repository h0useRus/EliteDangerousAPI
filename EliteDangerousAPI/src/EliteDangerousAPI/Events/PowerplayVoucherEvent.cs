using NSW.EliteDangerous.Internals;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class PowerplayVoucherEvent : JournalEvent
    {
        [JsonProperty("Power")]
        public string Power { get; internal set; }

        [JsonProperty("Systems")]
        public string[] Systems { get; internal set; }

        internal static PowerplayVoucherEvent Execute(string json, EliteDangerousAPI api) => api.Powerplay.InvokeEvent(JsonHelper.FromJson<PowerplayVoucherEvent>(json));
    }
}