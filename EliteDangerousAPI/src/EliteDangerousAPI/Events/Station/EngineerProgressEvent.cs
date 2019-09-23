using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class EngineerProgressEvent : JournalEvent
    {
        [JsonProperty("Engineers")]
        public EngineerProgress[] Engineers { get; internal set; }

        internal static EngineerProgressEvent Execute(string json, API.EliteDangerousAPI api) => api.Station.InvokeEvent(api.FromJson<EngineerProgressEvent>(json));
    }
}