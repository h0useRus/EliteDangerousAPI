namespace NSW.EliteDangerous.Events
{
    public class RefuelPartialEvent : RefuelAllEvent
    {
        internal new static RefuelPartialEvent Execute(string json, API.EliteDangerousAPI api) => api.Station.InvokeEvent(api.FromJson<RefuelPartialEvent>(json));
    }
}