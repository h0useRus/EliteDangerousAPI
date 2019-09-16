using NSW.EliteDangerous.Internals;

namespace NSW.EliteDangerous.Events
{
    public class JoinedSquadronEvent : SquadronEvent
    {
        internal static JoinedSquadronEvent Execute(string json, EliteDangerousAPI api) => api.Squadron.InvokeEvent(JsonHelper.FromJson<JoinedSquadronEvent>(json));
    }
}