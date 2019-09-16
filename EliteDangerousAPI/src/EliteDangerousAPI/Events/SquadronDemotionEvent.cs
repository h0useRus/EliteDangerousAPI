namespace NSW.EliteDangerous.Events
{
    public class SquadronDemotionEvent : SquadronPromotionEvent
    {
        internal new static SquadronDemotionEvent Execute(string json, EliteDangerousAPI api) => api.Squadron.InvokeEvent(api.FromJson<SquadronDemotionEvent>(json));
    }
}