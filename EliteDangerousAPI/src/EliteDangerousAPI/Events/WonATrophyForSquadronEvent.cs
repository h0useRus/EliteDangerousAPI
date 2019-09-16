namespace NSW.EliteDangerous.Events
{
    public class WonATrophyForSquadronEvent : SquadronEvent
    {
        internal static WonATrophyForSquadronEvent Execute(string json, EliteDangerousAPI api) => api.Squadron.InvokeEvent(api.FromJson<WonATrophyForSquadronEvent>(json));
    }
}