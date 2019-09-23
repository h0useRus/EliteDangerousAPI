using Newtonsoft.Json;
using NSW.EliteDangerous.Events.Entities;

namespace NSW.EliteDangerous.Events
{
    public class LoadGameEvent : JournalEvent
    {
        [JsonProperty("Commander")]
        public string Commander { get; internal set; }

        [JsonProperty("Horizons")]
        public bool? Horizons { get; internal set; }

        [JsonProperty("Ship")]
        public string Ship { get; internal set; }

        [JsonProperty("Ship_Localised")]
        public string ShipLocalised { get; internal set; }

        [JsonProperty("ShipID")]
        public long ShipId { get; internal set; }

        [JsonProperty("ShipName")]
        public string ShipName { get; internal set; }

        [JsonProperty("ShipIdent")]
        public string ShipIdent { get; internal set; }

        [JsonProperty("FuelLevel")]
        public double FuelLevel { get; internal set; }

        [JsonProperty("FuelCapacity")]
        public double FuelCapacity { get; internal set; }

        [JsonProperty("GameMode")]
        public GameMode GameMode { get; internal set; }

        [JsonProperty("Credits")]
        public long Credits { get; internal set; }

        [JsonProperty("Loan")]
        public long Loan { get; internal set; }

        [JsonProperty]
        public string Group { get; internal set; }

        [JsonProperty("FID")]
        public string FrontierId { get; internal set; }

        [JsonProperty]
        public bool? StartLanded { get; internal set; }

        internal static LoadGameEvent Execute(string json, API.EliteDangerousAPI api) => api.Game.InvokeEvent(api.FromJson<LoadGameEvent>(json));
    }
}