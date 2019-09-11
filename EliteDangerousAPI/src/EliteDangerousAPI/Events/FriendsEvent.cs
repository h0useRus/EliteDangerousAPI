using NSW.EliteDangerous.Internals;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class FriendsEvent : JournalEvent
    {
        [JsonProperty]
        public string Status { get; set; }

        [JsonProperty]
        public string Name { get; set; }

        internal static FriendsEvent Execute(string json, EliteDangerousAPI api) => api.Player.InvokeEvent(JsonHelper.FromJson<FriendsEvent>(json));
    }
}