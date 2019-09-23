namespace NSW.EliteDangerous.Events
{
    public class CrewLaunchFighterEvent : CrewEvent
    {
        internal static CrewLaunchFighterEvent Execute(string json, API.EliteDangerousAPI api) => api.Crew.InvokeEvent(api.FromJson<CrewLaunchFighterEvent>(json));
    }
}