using Newtonsoft.Json;

namespace NSW.EliteDangerous.API.Events
{
    public class FriendsEvent : JournalEvent
    {
        [JsonProperty]
        public FriendStatus Status { get; set; }

        [JsonProperty]
        public string Name { get; set; }

        internal static FriendsEvent Execute(string json, API.EliteDangerousAPI api) => api.PlayerEvents.InvokeEvent(api.FromJson<FriendsEvent>(json));
    }
}