namespace NSW.EliteDangerous.API.Events
{
    public class LeftSquadronEvent : SquadronEvent
    {
        internal static LeftSquadronEvent Execute(string json, API.EliteDangerousAPI api) => api.Squadron.InvokeEvent(api.FromJson<LeftSquadronEvent>(json));
    }
}