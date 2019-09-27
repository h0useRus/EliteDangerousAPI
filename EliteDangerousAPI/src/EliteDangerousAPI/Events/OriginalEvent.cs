namespace NSW.EliteDangerous.API.Events
{
    public class OriginalEvent
    {
        /// <summary>  Event name </summary>
        public string EventName { get; internal set; }
        /// <summary>             Original journal json  </summary>
        public string Source { get; internal set; }
        /// <summary> Set this <c>true</c> for ignore processing it </summary>
        public bool Ignore { get; set; }
    }
}