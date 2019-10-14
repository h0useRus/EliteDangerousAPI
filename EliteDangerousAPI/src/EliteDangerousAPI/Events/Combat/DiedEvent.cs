using Newtonsoft.Json;
using NSW.EliteDangerous.API.Internals;

namespace NSW.EliteDangerous.API.Events
{
    public class DiedEvent : JournalEvent
    {
        [JsonProperty("KillerName")]
        public string KillerName { get; internal set; }

        [JsonProperty("KillerName_Localised")]
        public string KillerNameLocalised { get; internal set; }

        [JsonProperty("KillerShip")]
        public string KillerShip { get; internal set; }

        [JsonIgnore]public ShipModel KillerShipModel => EnumHelper.GetShipModel(KillerShip);

        [JsonProperty("KillerRank")]
        public CombatRank KillerRank { get; internal set; }

        [JsonProperty("Killers")]
        public Killer[] Killers { get; internal set; }

        internal static DiedEvent Execute(string json, API.EliteDangerousAPI api) => api.CombatEvents.InvokeEvent(api.FromJson<DiedEvent>(json));
    }
}