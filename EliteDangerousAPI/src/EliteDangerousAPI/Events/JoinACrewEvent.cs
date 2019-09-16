﻿using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class JoinACrewEvent : JournalEvent
    {
        [JsonProperty("Captain")]
        public string Captain { get; set; }

        internal static JoinACrewEvent Execute(string json, EliteDangerousAPI api) => api.Crew.InvokeEvent(api.FromJson<JoinACrewEvent>(json));
    }
}