using NSW.EliteDangerous.Internals;

namespace NSW.EliteDangerous.Events
{
    public class KickedFromSquadronEvent : SquadronEvent
    {
        internal static KickedFromSquadronEvent Execute(string json, EliteDangerousAPI api) => api.Squadron.InvokeEvent(JsonHelper.FromJson<KickedFromSquadronEvent>(json));
    }
}