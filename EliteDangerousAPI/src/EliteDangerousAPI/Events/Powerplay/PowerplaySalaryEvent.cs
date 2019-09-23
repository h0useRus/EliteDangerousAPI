using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class PowerplaySalaryEvent : PowerplayEventBaseEvent
    {
        [JsonProperty("Amount")]
        public long Amount { get; internal set; }

        internal static PowerplaySalaryEvent Execute(string json, API.EliteDangerousAPI api) => api.Powerplay.InvokeEvent(api.FromJson<PowerplaySalaryEvent>(json));
    }
}