using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class AfmuRepairsEvent : JournalEvent
    {
        [JsonProperty("Module")]
        public string Module { get; internal set; }

        [JsonProperty("Module_Localised")]
        public string ModuleLocalised { get; internal set; }

        [JsonProperty("FullyRepaired")]
        public bool FullyRepaired { get; internal set; }

        [JsonProperty("Health")]
        public double Health { get; internal set; }

        internal static AfmuRepairsEvent Execute(string json, EliteDangerousAPI api) => api.Ship.InvokeEvent(api.FromJson<AfmuRepairsEvent>(json));
    }
}