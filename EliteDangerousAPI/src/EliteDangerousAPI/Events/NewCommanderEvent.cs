﻿using NSW.EliteDangerous.Internals;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class NewCommanderEvent : CommanderEvent
    {
        [JsonProperty("Package")]
        public string Package { get; internal set; }

        internal new static NewCommanderEvent Execute(string json, EliteDangerousAPI api) => api.Player.InvokeEvent(JsonHelper.FromJson<NewCommanderEvent>(json));
    }
}