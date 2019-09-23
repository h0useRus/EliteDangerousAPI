namespace NSW.EliteDangerous.API.Events
{
    public class KickedFromSquadronEvent : SquadronEvent
    {
        internal static KickedFromSquadronEvent Execute(string json, API.EliteDangerousAPI api) => api.Squadron.InvokeEvent(api.FromJson<KickedFromSquadronEvent>(json));
    }
}