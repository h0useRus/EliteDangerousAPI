using NSW.EliteDangerous.Internals;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class FuelScoopEvent : JournalEvent
    {
        [JsonProperty("Scooped")]
        public double Scooped { get; internal set; }

        [JsonProperty("Total")]
        public double Total { get; internal set; }

        internal static FuelScoopEvent Execute(string json, EliteDangerousAPI api) => api.Ship.InvokeEvent(JsonHelper.FromJson<FuelScoopEvent>(json));
    }
}