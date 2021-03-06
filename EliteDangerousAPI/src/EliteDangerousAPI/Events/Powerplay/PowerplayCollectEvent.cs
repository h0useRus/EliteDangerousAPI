using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class PowerplayCollectEvent : PowerplayEventBaseEvent
    {
        [JsonProperty("Type")]
        public string Type { get; internal set; }

        [JsonProperty("Type_Localised")]
        public string TypeLocalised { get; internal set; }

        [JsonProperty("Count")]
        public long Count { get; internal set; }

        internal static PowerplayCollectEvent Execute(string json, API.EliteDangerousAPI api) => api.PowerplayEvents.InvokeEvent(api.FromJson<PowerplayCollectEvent>(json));
    }
}