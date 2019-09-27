namespace NSW.EliteDangerous.API.Events
{
    public class AppliedToSquadronEvent : SquadronEvent
    {
        internal static AppliedToSquadronEvent Execute(string json, API.EliteDangerousAPI api) => api.SquadronEvents.InvokeEvent(api.FromJson<AppliedToSquadronEvent>(json));
    }
}