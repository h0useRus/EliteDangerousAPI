using Newtonsoft.Json;
using NSW.EliteDangerous.API.Internals;

namespace NSW.EliteDangerous.API.Events
{
    public class LoadoutEvent : JournalEvent
    {
        [JsonProperty("Ship")]
        public string ShipType { get; internal set; }

        [JsonIgnore] public ShipModel ShipModel => EnumHelper.GetShipModel(ShipType);

        [JsonProperty("ShipID")]
        public long ShipId { get; internal set; }

        [JsonProperty("ShipName")]
        public string ShipName { get; internal set; }

        [JsonProperty("ShipIdent")]
        public string ShipIdent { get; internal set; }

        [JsonProperty("HullValue")]
        public long HullValue { get; internal set; }

        [JsonProperty("ModulesValue")]
        public long ModulesValue { get; internal set; }

        [JsonProperty("UnladenMass")]
        public double UnladenMass { get; internal set; }

        [JsonProperty("FuelCapacity")]
        public FuelLoadout FuelCapacity { get; internal set; }

        [JsonProperty("CargoCapacity")]
        public long CargoCapacity { get; internal set; }

        [JsonProperty("MaxJumpRange")]
        public double MaxJumpRange { get; internal set; }

        [JsonProperty("Rebuy")]
        public long? Rebuy { get; internal set; }

        [JsonProperty("Hot")]
        public bool? Hot { get; internal set; }

        [JsonProperty("HullHealth")]
        public double HullHealth { get; internal set; }

        [JsonProperty("Modules")]
        public Module[] Modules { get; internal set; }

        internal static LoadoutEvent Execute(string json, API.EliteDangerousAPI api) => api.ShipEvents.InvokeEvent(api.FromJson<LoadoutEvent>(json));
    }
}