namespace NSW.EliteDangerous.API.Events
{
    public class CrewMemberQuitsEvent : CrewEvent
    {
        internal static CrewMemberQuitsEvent Execute(string json, API.EliteDangerousAPI api) => api.Crew.InvokeEvent(api.FromJson<CrewMemberQuitsEvent>(json));
    }
}