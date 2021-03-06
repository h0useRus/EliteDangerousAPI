namespace NSW.EliteDangerous.API.Events
{
    public class RefuelPartialEvent : RefuelAllEvent
    {
        internal new static RefuelPartialEvent Execute(string json, API.EliteDangerousAPI api) => api.StationEvents.InvokeEvent(api.FromJson<RefuelPartialEvent>(json));
    }
}