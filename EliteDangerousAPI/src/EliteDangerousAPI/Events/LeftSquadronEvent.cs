namespace NSW.EliteDangerous.Events
{
    public class LeftSquadronEvent : SquadronEvent
    {
        internal static LeftSquadronEvent Execute(string json, EliteDangerousAPI api) => api.Squadron.InvokeEvent(api.FromJson<LeftSquadronEvent>(json));
    }
}