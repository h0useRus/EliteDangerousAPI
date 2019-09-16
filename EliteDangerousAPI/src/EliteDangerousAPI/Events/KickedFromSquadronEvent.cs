namespace NSW.EliteDangerous.Events
{
    public class KickedFromSquadronEvent : SquadronEvent
    {
        internal static KickedFromSquadronEvent Execute(string json, EliteDangerousAPI api) => api.Squadron.InvokeEvent(api.FromJson<KickedFromSquadronEvent>(json));
    }
}