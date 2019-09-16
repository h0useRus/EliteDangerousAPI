using NSW.EliteDangerous.Internals;

namespace NSW.EliteDangerous.Events
{
    public class CrewFireEvent : CrewBaseEvent
    {
        internal static CrewFireEvent Execute(string json, EliteDangerousAPI api) => api.Crew.InvokeEvent(JsonHelper.FromJson<CrewFireEvent>(json));
    }
}