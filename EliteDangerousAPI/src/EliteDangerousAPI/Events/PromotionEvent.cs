using NSW.EliteDangerous.Internals;

namespace NSW.EliteDangerous.Events
{
    public class PromotionEvent : RankEvent
    {
        internal new static PromotionEvent Execute(string json, EliteDangerousAPI api) => api.Player.InvokeEvent(JsonHelper.FromJson<PromotionEvent>(json));
    }
}