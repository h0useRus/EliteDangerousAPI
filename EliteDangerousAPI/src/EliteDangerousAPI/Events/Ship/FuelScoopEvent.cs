using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class FuelScoopEvent : JournalEvent
    {
        [JsonProperty("Scooped")]
        public double Scooped { get; internal set; }

        [JsonProperty("Total")]
        public double Total { get; internal set; }

        internal static FuelScoopEvent Execute(string json, API.EliteDangerousAPI api) => api.Ship.InvokeEvent(api.FromJson<FuelScoopEvent>(json));
    }
}