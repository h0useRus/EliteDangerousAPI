using NSW.EliteDangerous.Internals;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class FighterRebuiltEvent : JournalEvent
    {
        [JsonProperty("ID")]
        public int Id { get; internal set; }

        [JsonProperty("Loadout")]
        public string Loadout { get; internal set; }

        internal static FighterRebuiltEvent Execute(string json, EliteDangerousAPI api) => api.Ship.InvokeEvent(JsonHelper.FromJson<FighterRebuiltEvent>(json));
    }
}