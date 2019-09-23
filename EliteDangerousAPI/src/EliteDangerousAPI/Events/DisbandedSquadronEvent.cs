namespace NSW.EliteDangerous.Events
{
    public class DisbandedSquadronEvent : SquadronEvent
    {
        internal static DisbandedSquadronEvent Execute(string json, API.EliteDangerousAPI api) => api.Squadron.InvokeEvent(api.FromJson<DisbandedSquadronEvent>(json));
    }
}