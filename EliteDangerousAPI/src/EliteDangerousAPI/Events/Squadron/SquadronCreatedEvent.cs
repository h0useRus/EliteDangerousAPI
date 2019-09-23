namespace NSW.EliteDangerous.API.Events
{
    public class SquadronCreatedEvent : SquadronEvent
    {
        internal static SquadronCreatedEvent Execute(string json, API.EliteDangerousAPI api) => api.Squadron.InvokeEvent(api.FromJson<SquadronCreatedEvent>(json));
    }
}