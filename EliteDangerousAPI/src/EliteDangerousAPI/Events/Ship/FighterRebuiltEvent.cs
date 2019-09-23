using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class FighterRebuiltEvent : JournalEvent
    {
        [JsonProperty("ID")]
        public int Id { get; internal set; }

        [JsonProperty("Loadout")]
        public string Loadout { get; internal set; }

        internal static FighterRebuiltEvent Execute(string json, API.EliteDangerousAPI api) => api.Ship.InvokeEvent(api.FromJson<FighterRebuiltEvent>(json));
    }
}