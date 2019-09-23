namespace NSW.EliteDangerous.API.Events
{
    public class WonATrophyForSquadronEvent : SquadronEvent
    {
        internal static WonATrophyForSquadronEvent Execute(string json, API.EliteDangerousAPI api) => api.Squadron.InvokeEvent(api.FromJson<WonATrophyForSquadronEvent>(json));
    }
}