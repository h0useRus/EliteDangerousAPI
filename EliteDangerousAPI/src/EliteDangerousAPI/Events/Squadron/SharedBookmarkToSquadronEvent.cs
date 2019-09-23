namespace NSW.EliteDangerous.API.Events
{
    public class SharedBookmarkToSquadronEvent : SquadronEvent
    {
        internal static SharedBookmarkToSquadronEvent Execute(string json, API.EliteDangerousAPI api) => api.Squadron.InvokeEvent(api.FromJson<SharedBookmarkToSquadronEvent>(json));
    }
}