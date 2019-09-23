using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class PowerplayDefectEvent : JournalEvent
    {
        [JsonProperty]
        public string FromPower { get; internal set; }

        [JsonProperty]
        public string ToPower { get; internal set; }

        internal static PowerplayDefectEvent Execute(string json, API.EliteDangerousAPI api) => api.Powerplay.InvokeEvent(api.FromJson<PowerplayDefectEvent>(json));
    }
}