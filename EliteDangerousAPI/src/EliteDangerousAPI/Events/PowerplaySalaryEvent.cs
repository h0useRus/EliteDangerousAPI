using NSW.EliteDangerous.Internals;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class PowerplaySalaryEvent : PowerplayEventBaseEvent
    {
        [JsonProperty("Amount")]
        public long Amount { get; internal set; }

        internal static PowerplaySalaryEvent Execute(string json, EliteDangerousAPI api) => api.Powerplay.InvokeEvent(JsonHelper.FromJson<PowerplaySalaryEvent>(json));
    }
}