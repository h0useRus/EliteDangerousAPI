using NSW.EliteDangerous.Internals;

namespace NSW.EliteDangerous.Events
{
    public class InvitedToSquadronEvent : SquadronEvent
    {
        internal static InvitedToSquadronEvent Execute(string json, EliteDangerousAPI api) => api.Squadron.InvokeEvent(JsonHelper.FromJson<InvitedToSquadronEvent>(json));
    }
}