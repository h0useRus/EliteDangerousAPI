namespace NSW.EliteDangerous.API.Events
{
    public class SelfDestructEvent : JournalEvent
    {
        internal static SelfDestructEvent Execute(string json, API.EliteDangerousAPI api) => api.ShipEvents.InvokeEvent(api.FromJson<SelfDestructEvent>(json));
    }
}