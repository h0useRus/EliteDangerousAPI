using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class HullDamageEvent : JournalEvent
    {
        [JsonProperty("Health")]
        public double Health { get; internal set; }

        [JsonProperty("PlayerPilot")]
        public bool PlayerPilot { get; internal set; }

        [JsonProperty("Fighter")]
        public bool Fighter { get; internal set; }

        internal static HullDamageEvent Execute(string json, API.EliteDangerousAPI api) => api.CombatEvents.InvokeEvent(api.FromJson<HullDamageEvent>(json));
    }
}