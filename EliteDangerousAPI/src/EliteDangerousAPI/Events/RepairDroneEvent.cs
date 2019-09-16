using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class RepairDroneEvent : JournalEvent
    {
        [JsonProperty("HullRepaired")]
        public double HullRepaired { get; internal set; }

        [JsonProperty("CockpitRepaired")]
        public double CockpitRepaired { get; internal set; }

        [JsonProperty("CorrosionRepaired")]
        public double CorrosionRepaired { get; internal set; }

        internal static RepairDroneEvent Execute(string json, EliteDangerousAPI api) => api.Ship.InvokeEvent(api.FromJson<RepairDroneEvent>(json));
    }
}