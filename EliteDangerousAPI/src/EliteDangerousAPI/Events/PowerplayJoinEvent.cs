using NSW.EliteDangerous.Internals;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class PowerplayJoinEvent : JournalEvent
    {
        [JsonProperty]
        public string Power { get; internal set; }

        internal static PowerplayJoinEvent Execute(string json, EliteDangerousAPI api) => api.Powerplay.InvokeEvent(JsonHelper.FromJson<PowerplayJoinEvent>(json));
    }
}