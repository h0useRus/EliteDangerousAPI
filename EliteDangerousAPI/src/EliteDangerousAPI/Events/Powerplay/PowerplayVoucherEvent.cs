using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class PowerplayVoucherEvent : PowerplayEventBaseEvent
    {
        [JsonProperty("Systems")]
        public string[] Systems { get; internal set; }

        internal static PowerplayVoucherEvent Execute(string json, API.EliteDangerousAPI api) => api.PowerplayEvents.InvokeEvent(api.FromJson<PowerplayVoucherEvent>(json));
    }
}