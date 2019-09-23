using Newtonsoft.Json;

namespace NSW.EliteDangerous.API
{
    public class PassengersStatistics
    {
        [JsonProperty("Passengers_Missions_Accepted")]
        public long MissionsAccepted { get; internal set; }

        [JsonProperty("Passengers_Missions_Disgruntled")]
        public long MissionsDisgruntled { get; internal set; }

        [JsonProperty("Passengers_Missions_Bulk")]
        public long MissionsBulk { get; internal set; }

        [JsonProperty("Passengers_Missions_VIP")]
        public long MissionsVip { get; internal set; }

        [JsonProperty("Passengers_Missions_Delivered")]
        public long MissionsDelivered { get; internal set; }

        [JsonProperty("Passengers_Missions_Ejected")]
        public long MissionsEjected { get; internal set; }
    }
}