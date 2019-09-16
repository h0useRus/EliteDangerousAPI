using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class DockingDeniedEvent : DockEvent
    {
        [JsonProperty("Reason")]
        public string Reason { get; internal set; }

        internal static DockingDeniedEvent Execute(string json, EliteDangerousAPI api) => api.Travel.InvokeEvent(api.FromJson<DockingDeniedEvent>(json));
    }
}