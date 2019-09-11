﻿using NSW.EliteDangerous.Internals;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class QuitACrewEvent : JournalEvent
    {
        [JsonProperty("Captain")]
        public string Captain { get; internal set; }

        internal static QuitACrewEvent Execute(string json, EliteDangerousAPI api) => api.Crew.InvokeEvent(JsonHelper.FromJson<QuitACrewEvent>(json));
    }
}