using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class EscapeInterdictionEvent : JournalEvent
    {
        [JsonProperty("Interdictor")]
        public string Interdictor { get; internal set; }

        [JsonProperty("Interdictor_Localised")]
        public string InterdictorLocalised { get; internal set; }

        [JsonProperty("IsPlayer")]
        public bool IsPlayer { get; internal set; }

        internal static EscapeInterdictionEvent Execute(string json, API.EliteDangerousAPI api) => api.CombatEvents.InvokeEvent(api.FromJson<EscapeInterdictionEvent>(json));
    }
}