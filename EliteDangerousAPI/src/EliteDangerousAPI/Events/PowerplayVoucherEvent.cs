using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class PowerplayVoucherEvent : PowerplayEventBaseEvent
    {
        [JsonProperty("Systems")]
        public string[] Systems { get; internal set; }

        internal static PowerplayVoucherEvent Execute(string json, EliteDangerousAPI api) => api.Powerplay.InvokeEvent(api.FromJson<PowerplayVoucherEvent>(json));
    }
}