﻿using NSW.EliteDangerous.Internals;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class AsteroidCrackedEvent : JournalEvent
    {
        [JsonProperty("Body")]
        public string Body { get; internal set; }

        internal static AsteroidCrackedEvent Execute(string json, EliteDangerousAPI api) => api.Trade.InvokeEvent(JsonHelper.FromJson<AsteroidCrackedEvent>(json));
    }
}