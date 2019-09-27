using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class ModuleSellRemoteEvent : ModuleSellEvent
    {
        [JsonProperty("StorageSlot")]
        public long StorageSlot { get; internal set; }

        [JsonProperty("ServerId")]
        public long ServerId { get; internal set; }

        internal new static ModuleSellRemoteEvent Execute(string json, API.EliteDangerousAPI api) => api.StationEvents.InvokeEvent(api.FromJson<ModuleSellRemoteEvent>(json));
    }
}