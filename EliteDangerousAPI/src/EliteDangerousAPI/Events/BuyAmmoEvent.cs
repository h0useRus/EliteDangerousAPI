using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class BuyAmmoEvent : JournalEvent
    {
        [JsonProperty("Cost")]
        public long Cost { get; internal set; }

        internal static BuyAmmoEvent Execute(string json, EliteDangerousAPI api) => api.Station.InvokeEvent(api.FromJson<BuyAmmoEvent>(json));
    }
}