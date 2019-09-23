namespace NSW.EliteDangerous.Events
{
    public class CrewFireEvent : CrewBaseEvent
    {
        internal static CrewFireEvent Execute(string json, API.EliteDangerousAPI api) => api.Crew.InvokeEvent(api.FromJson<CrewFireEvent>(json));
    }
}