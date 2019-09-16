namespace NSW.EliteDangerous.Events
{
    public class ClearSavedGameEvent : CommanderEvent
    {
        internal new static ClearSavedGameEvent Execute(string json, EliteDangerousAPI api) => api.Game.InvokeEvent(api.FromJson<ClearSavedGameEvent>(json));
    }
}