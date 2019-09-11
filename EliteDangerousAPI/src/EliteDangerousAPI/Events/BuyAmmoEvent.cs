using NSW.EliteDangerous.Internals;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class BuyAmmoEvent : JournalEvent
    {
        [JsonProperty("Cost")]
        public long Cost { get; internal set; }

        internal static BuyAmmoEvent Execute(string json, EliteDangerousAPI api) => api.Station.InvokeEvent(JsonHelper.FromJson<BuyAmmoEvent>(json));
    }
}