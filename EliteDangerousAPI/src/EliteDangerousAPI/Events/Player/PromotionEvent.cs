namespace NSW.EliteDangerous.API.Events
{
    public class PromotionEvent : RankEvent
    {
        internal new static PromotionEvent Execute(string json, API.EliteDangerousAPI api) => api.PlayerEvents.InvokeEvent(api.FromJson<PromotionEvent>(json));
    }
}