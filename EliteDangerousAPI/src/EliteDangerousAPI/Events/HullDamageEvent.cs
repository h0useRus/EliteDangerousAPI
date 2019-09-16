using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class HullDamageEvent : JournalEvent
    {
        [JsonProperty("Health")]
        public double Health { get; internal set; }

        [JsonProperty("PlayerPilot")]
        public bool PlayerPilot { get; internal set; }

        [JsonProperty("Fighter")]
        public bool Fighter { get; internal set; }

        internal static HullDamageEvent Execute(string json, EliteDangerousAPI api) => api.Combat.InvokeEvent(api.FromJson<HullDamageEvent>(json));
    }
}