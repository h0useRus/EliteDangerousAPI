namespace NSW.EliteDangerous.API.Events
{
    public class SharedBookmarkToSquadronEvent : SquadronEvent
    {
        internal static SharedBookmarkToSquadronEvent Execute(string json, API.EliteDangerousAPI api) => api.SquadronEvents.InvokeEvent(api.FromJson<SharedBookmarkToSquadronEvent>(json));
    }
}