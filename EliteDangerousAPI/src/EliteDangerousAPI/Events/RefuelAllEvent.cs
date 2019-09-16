using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class RefuelAllEvent : JournalEvent
    {
        [JsonProperty("Cost")]
        public long Cost { get; internal set; }

        [JsonProperty("Amount")]
        public double Amount { get; internal set; }

        internal static RefuelAllEvent Execute(string json, EliteDangerousAPI api) => api.Station.InvokeEvent(api.FromJson<RefuelAllEvent>(json));
    }
}