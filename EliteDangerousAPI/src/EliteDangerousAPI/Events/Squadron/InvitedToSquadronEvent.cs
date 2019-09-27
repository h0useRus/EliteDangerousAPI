namespace NSW.EliteDangerous.API.Events
{
    public class InvitedToSquadronEvent : SquadronEvent
    {
        internal static InvitedToSquadronEvent Execute(string json, API.EliteDangerousAPI api) => api.SquadronEvents.InvokeEvent(api.FromJson<InvitedToSquadronEvent>(json));
    }
}