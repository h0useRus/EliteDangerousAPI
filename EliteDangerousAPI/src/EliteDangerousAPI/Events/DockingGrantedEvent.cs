using NSW.EliteDangerous.Internals;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class DockingGrantedEvent : DockEvent
    {
        [JsonProperty("LandingPad")]
        public int LandingPad { get; internal set; }

        internal static DockingGrantedEvent Execute(string json, EliteDangerousAPI api) => api.Travel.InvokeEvent(JsonHelper.FromJson<DockingGrantedEvent>(json));
    }
}