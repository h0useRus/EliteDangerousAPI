namespace NSW.EliteDangerous.API.Events
{
    public class AppliedToSquadronEvent : SquadronEvent
    {
        internal static AppliedToSquadronEvent Execute(string json, API.EliteDangerousAPI api) => api.Squadron.InvokeEvent(api.FromJson<AppliedToSquadronEvent>(json));
    }
}