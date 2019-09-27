using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class ReservoirReplenishedEvent : JournalEvent
    {
        [JsonProperty("FuelMain")]
        public double FuelMain { get; set; }

        [JsonProperty("FuelReservoir")]
        public double FuelReservoir { get; set; }

        internal static ReservoirReplenishedEvent Execute(string json, API.EliteDangerousAPI api) => api.ShipEvents.InvokeEvent(api.FromJson<ReservoirReplenishedEvent>(json));
    }
}