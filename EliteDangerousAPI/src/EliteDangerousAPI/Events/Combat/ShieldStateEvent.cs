using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class ShieldStateEvent : JournalEvent
    {
        [JsonProperty("ShieldsUp")]
        public bool ShieldsUp { get; internal set; }

        internal static ShieldStateEvent Execute(string json, API.EliteDangerousAPI api) => api.CombatEvents.InvokeEvent(api.FromJson<ShieldStateEvent>(json));
    }
}