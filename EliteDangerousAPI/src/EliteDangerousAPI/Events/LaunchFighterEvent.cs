﻿using NSW.EliteDangerous.Internals;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class LaunchFighterEvent : JournalEvent
    {
        [JsonProperty("Loadout")]
        public string Loadout { get; internal set; }

        [JsonProperty("PlayerControlled")]
        public bool PlayerControlled { get; internal set; }

        internal static LaunchFighterEvent Execute(string json, EliteDangerousAPI api) => api.Ship.InvokeEvent(JsonHelper.FromJson<LaunchFighterEvent>(json));
    }
}