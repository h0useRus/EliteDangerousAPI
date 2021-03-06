using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class NewCommanderEvent : CommanderEvent
    {
        [JsonProperty("Package")]
        public string Package { get; internal set; }

        internal new static NewCommanderEvent Execute(string json, API.EliteDangerousAPI api) => api.PlayerEvents.InvokeEvent(api.FromJson<NewCommanderEvent>(json));
    }
}