﻿using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class CommanderEvent : JournalEvent
    {
        [JsonProperty("Name")]
        public string Name { get; internal set; }

        [JsonProperty("FID")]
        public string FrontierId { get; internal set; }

        internal static CommanderEvent Execute(string json, API.EliteDangerousAPI api) => api.Player.InvokeEvent(api.FromJson<CommanderEvent>(json));
    }
}