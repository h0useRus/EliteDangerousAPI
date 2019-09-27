using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class JetConeBoostEvent : JournalEvent
    {
        [JsonProperty("BoostValue")]
        public double BoostValue { get; internal set; }

        internal static JetConeBoostEvent Execute(string json, API.EliteDangerousAPI api) => api.ShipEvents.InvokeEvent(api.FromJson<JetConeBoostEvent>(json));
    }
}