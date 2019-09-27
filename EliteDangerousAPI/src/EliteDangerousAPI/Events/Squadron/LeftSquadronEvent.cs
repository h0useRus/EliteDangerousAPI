namespace NSW.EliteDangerous.API.Events
{
    public class LeftSquadronEvent : SquadronEvent
    {
        internal static LeftSquadronEvent Execute(string json, API.EliteDangerousAPI api) => api.SquadronEvents.InvokeEvent(api.FromJson<LeftSquadronEvent>(json));
    }
}