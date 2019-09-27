namespace NSW.EliteDangerous.API.Events
{
    public class SquadronDemotionEvent : SquadronPromotionEvent
    {
        internal new static SquadronDemotionEvent Execute(string json, API.EliteDangerousAPI api) => api.SquadronEvents.InvokeEvent(api.FromJson<SquadronDemotionEvent>(json));
    }
}