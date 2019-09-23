namespace NSW.EliteDangerous.API.Events
{
    public class SquadronDemotionEvent : SquadronPromotionEvent
    {
        internal new static SquadronDemotionEvent Execute(string json, API.EliteDangerousAPI api) => api.Squadron.InvokeEvent(api.FromJson<SquadronDemotionEvent>(json));
    }
}