using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class BuyAmmoEvent : JournalEvent
    {
        [JsonProperty("Cost")]
        public long Cost { get; internal set; }

        internal static BuyAmmoEvent Execute(string json, API.EliteDangerousAPI api) => api.StationEvents.InvokeEvent(api.FromJson<BuyAmmoEvent>(json));
    }
}