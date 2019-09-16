using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class JetConeDamageEvent : JournalEvent
    {
        [JsonProperty("Module")]
        public string Module { get; internal set; }

        [JsonProperty("Module_Localised")]
        public string ModuleLocalised { get; internal set; }

        internal static JetConeDamageEvent Execute(string json, EliteDangerousAPI api) => api.Ship.InvokeEvent(api.FromJson<JetConeDamageEvent>(json));
    }
}