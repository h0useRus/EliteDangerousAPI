namespace NSW.EliteDangerous.API.Events
{
    public class CrewFireEvent : CrewBaseEvent
    {
        internal static CrewFireEvent Execute(string json, API.EliteDangerousAPI api) => api.CrewEvents.InvokeEvent(api.FromJson<CrewFireEvent>(json));
    }
}