using NSW.EliteDangerous.Internals;

namespace NSW.EliteDangerous.Events
{
    public class SharedBookmarkToSquadronEvent : SquadronEvent
    {
        internal static SharedBookmarkToSquadronEvent Execute(string json, EliteDangerousAPI api) => api.Squadron.InvokeEvent(JsonHelper.FromJson<SharedBookmarkToSquadronEvent>(json));
    }
}