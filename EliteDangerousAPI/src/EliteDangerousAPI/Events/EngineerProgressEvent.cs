using NSW.EliteDangerous.Events.Entities;
using NSW.EliteDangerous.Internals;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class EngineerProgressEvent : JournalEvent
    {
        [JsonProperty("Engineers")]
        public EngineerProgress[] Engineers { get; internal set; }

        internal static EngineerProgressEvent Execute(string json, EliteDangerousAPI api) => api.Station.InvokeEvent(JsonHelper.FromJson<EngineerProgressEvent>(json));
    }
}