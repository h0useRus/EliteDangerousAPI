namespace NSW.EliteDangerous.API.Events
{
    public class CrewMemberJoinsEvent : CrewEvent
    {
        internal static CrewMemberJoinsEvent Execute(string json, API.EliteDangerousAPI api) => api.CrewEvents.InvokeEvent(api.FromJson<CrewMemberJoinsEvent>(json));
    }
}