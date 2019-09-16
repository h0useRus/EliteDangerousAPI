namespace NSW.EliteDangerous.Events
{
    public class SquadronCreatedEvent : SquadronEvent
    {
        internal static SquadronCreatedEvent Execute(string json, EliteDangerousAPI api) => api.Squadron.InvokeEvent(api.FromJson<SquadronCreatedEvent>(json));
    }
}