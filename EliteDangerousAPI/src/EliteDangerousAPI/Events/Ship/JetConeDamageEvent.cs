using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class JetConeDamageEvent : JournalEvent
    {
        [JsonProperty("Module")]
        public string Module { get; internal set; }

        [JsonProperty("Module_Localised")]
        public string ModuleLocalised { get; internal set; }

        internal static JetConeDamageEvent Execute(string json, API.EliteDangerousAPI api) => api.ShipEvents.InvokeEvent(api.FromJson<JetConeDamageEvent>(json));
    }
}