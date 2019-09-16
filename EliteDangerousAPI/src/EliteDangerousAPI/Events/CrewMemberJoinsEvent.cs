namespace NSW.EliteDangerous.Events
{
    public class CrewMemberJoinsEvent : CrewEvent
    {
        internal static CrewMemberJoinsEvent Execute(string json, EliteDangerousAPI api) => api.Crew.InvokeEvent(api.FromJson<CrewMemberJoinsEvent>(json));
    }
}