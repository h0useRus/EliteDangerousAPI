using NSW.EliteDangerous.Internals;

namespace NSW.EliteDangerous.Events
{
    public class AppliedToSquadronEvent : SquadronEvent
    {
        internal static AppliedToSquadronEvent Execute(string json, EliteDangerousAPI api) => api.Squadron.InvokeEvent(JsonHelper.FromJson<AppliedToSquadronEvent>(json));
    }
}