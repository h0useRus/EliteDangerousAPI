namespace NSW.EliteDangerous.API.Events
{
    public class WonATrophyForSquadronEvent : SquadronEvent
    {
        internal static WonATrophyForSquadronEvent Execute(string json, API.EliteDangerousAPI api) => api.SquadronEvents.InvokeEvent(api.FromJson<WonATrophyForSquadronEvent>(json));
    }
}