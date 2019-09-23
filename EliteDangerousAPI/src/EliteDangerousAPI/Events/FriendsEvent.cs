using Newtonsoft.Json;
using NSW.EliteDangerous.API;

namespace NSW.EliteDangerous.Events
{
    public class FriendsEvent : JournalEvent
    {
        [JsonProperty]
        public FriendStatus Status { get; set; }

        [JsonProperty]
        public string Name { get; set; }

        internal static FriendsEvent Execute(string json, API.EliteDangerousAPI api) => api.Player.InvokeEvent(api.FromJson<FriendsEvent>(json));
    }
}