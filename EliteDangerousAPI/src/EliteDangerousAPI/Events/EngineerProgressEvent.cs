using Newtonsoft.Json;
using NSW.EliteDangerous.API;

namespace NSW.EliteDangerous.Events
{
    public class EngineerProgressEvent : JournalEvent
    {
        [JsonProperty("Engineers")]
        public EngineerProgress[] Engineers { get; internal set; }

        internal static EngineerProgressEvent Execute(string json, API.EliteDangerousAPI api) => api.Station.InvokeEvent(api.FromJson<EngineerProgressEvent>(json));
    }
}