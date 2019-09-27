namespace NSW.EliteDangerous.API.Events
{
    public class CrewLaunchFighterEvent : CrewEvent
    {
        internal static CrewLaunchFighterEvent Execute(string json, API.EliteDangerousAPI api) => api.CrewEvents.InvokeEvent(api.FromJson<CrewLaunchFighterEvent>(json));
    }
}