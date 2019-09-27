namespace NSW.EliteDangerous.API.Events
{
    public class JoinedSquadronEvent : SquadronEvent
    {
        internal static JoinedSquadronEvent Execute(string json, API.EliteDangerousAPI api) => api.SquadronEvents.InvokeEvent(api.FromJson<JoinedSquadronEvent>(json));
    }
}