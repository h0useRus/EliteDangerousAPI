namespace NSW.EliteDangerous.API.Events
{
    public class SquadronCreatedEvent : SquadronEvent
    {
        internal static SquadronCreatedEvent Execute(string json, API.EliteDangerousAPI api) => api.SquadronEvents.InvokeEvent(api.FromJson<SquadronCreatedEvent>(json));
    }
}