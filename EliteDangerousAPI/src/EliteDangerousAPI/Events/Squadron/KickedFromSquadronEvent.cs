namespace NSW.EliteDangerous.API.Events
{
    public class KickedFromSquadronEvent : SquadronEvent
    {
        internal static KickedFromSquadronEvent Execute(string json, API.EliteDangerousAPI api) => api.SquadronEvents.InvokeEvent(api.FromJson<KickedFromSquadronEvent>(json));
    }
}