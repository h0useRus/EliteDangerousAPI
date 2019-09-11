using NSW.EliteDangerous.Internals;

namespace NSW.EliteDangerous.Events
{
    public class WonATrophyForSquadronEvent : SquadronEvent
    {
        internal static WonATrophyForSquadronEvent Execute(string json, EliteDangerousAPI api) => api.Squadron.InvokeEvent(JsonHelper.FromJson<WonATrophyForSquadronEvent>(json));
    }
}