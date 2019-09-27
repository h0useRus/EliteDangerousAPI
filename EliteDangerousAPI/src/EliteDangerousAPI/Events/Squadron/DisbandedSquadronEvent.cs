namespace NSW.EliteDangerous.API.Events
{
    public class DisbandedSquadronEvent : SquadronEvent
    {
        internal static DisbandedSquadronEvent Execute(string json, API.EliteDangerousAPI api) => api.SquadronEvents.InvokeEvent(api.FromJson<DisbandedSquadronEvent>(json));
    }
}