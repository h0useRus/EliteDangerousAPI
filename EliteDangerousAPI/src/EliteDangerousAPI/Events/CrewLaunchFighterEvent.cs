using NSW.EliteDangerous.Internals;

namespace NSW.EliteDangerous.Events
{
    public class CrewLaunchFighterEvent : CrewEvent
    {
        internal static CrewLaunchFighterEvent Execute(string json, EliteDangerousAPI api) => api.Crew.InvokeEvent(JsonHelper.FromJson<CrewLaunchFighterEvent>(json));
    }
}