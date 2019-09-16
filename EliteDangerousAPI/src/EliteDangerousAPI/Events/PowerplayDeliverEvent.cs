using NSW.EliteDangerous.Internals;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class PowerplayDeliverEvent : PowerplayEventBaseEvent
    {
        [JsonProperty("Type")]
        public string Type { get; internal set; }

        [JsonProperty("Type_Localised")]
        public string TypeLocalised { get; internal set; }

        [JsonProperty("Count")]
        public long Count { get; internal set; }

        internal static PowerplayDeliverEvent Execute(string json, EliteDangerousAPI api) => api.Powerplay.InvokeEvent(JsonHelper.FromJson<PowerplayDeliverEvent>(json));
    }
}