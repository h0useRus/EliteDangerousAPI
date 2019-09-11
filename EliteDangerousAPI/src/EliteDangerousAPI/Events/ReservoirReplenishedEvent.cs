using NSW.EliteDangerous.Internals;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class ReservoirReplenishedEvent : JournalEvent
    {
        [JsonProperty("FuelMain")]
        public double FuelMain { get; set; }

        [JsonProperty("FuelReservoir")]
        public double FuelReservoir { get; set; }

        internal static ReservoirReplenishedEvent Execute(string json, EliteDangerousAPI api) => api.Ship.InvokeEvent(JsonHelper.FromJson<ReservoirReplenishedEvent>(json));
    }
}