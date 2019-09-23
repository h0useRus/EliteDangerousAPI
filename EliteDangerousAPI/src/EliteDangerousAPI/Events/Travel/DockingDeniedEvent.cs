using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class DockingDeniedEvent : DockEvent
    {
        [JsonProperty("Reason")]
        public string Reason { get; internal set; }

        internal static DockingDeniedEvent Execute(string json, API.EliteDangerousAPI api) => api.Travel.InvokeEvent(api.FromJson<DockingDeniedEvent>(json));
    }
}