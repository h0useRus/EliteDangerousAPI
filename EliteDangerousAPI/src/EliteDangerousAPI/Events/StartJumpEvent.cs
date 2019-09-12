﻿using NSW.EliteDangerous.Internals;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class StartJumpEvent : JournalEvent
    {
        [JsonProperty("JumpType")]
        public string JumpType { get; internal set; }

        [JsonProperty("StarSystem")]
        public string StarSystem { get; internal set; }

        [JsonProperty("SystemAddress")]
        public long SystemAddress { get; internal set; }

        [JsonProperty("StarClass")]
        public string StarClass { get; internal set; }

        internal static StartJumpEvent Execute(string json, EliteDangerousAPI api) => api.Travel.InvokeEvent(JsonHelper.FromJson<StartJumpEvent>(json));
    }
}