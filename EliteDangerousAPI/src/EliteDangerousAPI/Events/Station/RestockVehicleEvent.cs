using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class RestockVehicleEvent : JournalEvent
    {
        [JsonProperty("Type")]
        public string Type { get; internal set; }

        [JsonProperty("Loadout")]
        public string Loadout { get; internal set; }

        [JsonProperty("Cost")]
        public long Cost { get; internal set; }

        [JsonProperty("Count")]
        public long Count { get; internal set; }

        internal static RestockVehicleEvent Execute(string json, API.EliteDangerousAPI api) => api.Station.InvokeEvent(api.FromJson<RestockVehicleEvent>(json));
    }
}