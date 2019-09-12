﻿using NSW.EliteDangerous.Internals;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class ContinuedEvent : JournalEvent
    {
        [JsonProperty("Part")]
        public string Part { get; internal set; }

        internal static ContinuedEvent Execute(string json, EliteDangerousAPI api) => api.Game.InvokeEvent(JsonHelper.FromJson<ContinuedEvent>(json));
    }
}