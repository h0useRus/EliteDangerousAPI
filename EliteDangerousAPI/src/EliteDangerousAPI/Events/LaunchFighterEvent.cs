using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class LaunchFighterEvent : JournalEvent
    {
        [JsonProperty("ID")]
        public int Id { get; internal set; }

        [JsonProperty("Loadout")]
        public string Loadout { get; internal set; }

        [JsonProperty("PlayerControlled")]
        public bool PlayerControlled { get; internal set; }

        internal static LaunchFighterEvent Execute(string json, EliteDangerousAPI api) => api.Ship.InvokeEvent(api.FromJson<LaunchFighterEvent>(json));
    }
}