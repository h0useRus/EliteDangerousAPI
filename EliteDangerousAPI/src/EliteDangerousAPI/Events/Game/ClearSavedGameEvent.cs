namespace NSW.EliteDangerous.API.Events
{
    public class ClearSavedGameEvent : CommanderEvent
    {
        internal new static ClearSavedGameEvent Execute(string json, API.EliteDangerousAPI api) => api.Game.InvokeEvent(api.FromJson<ClearSavedGameEvent>(json));
    }
}