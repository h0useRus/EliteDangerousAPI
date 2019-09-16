namespace NSW.EliteDangerous.Events
{
    public class RefuelPartialEvent : RefuelAllEvent
    {
        internal new static RefuelPartialEvent Execute(string json, EliteDangerousAPI api) => api.Station.InvokeEvent(api.FromJson<RefuelPartialEvent>(json));
    }
}