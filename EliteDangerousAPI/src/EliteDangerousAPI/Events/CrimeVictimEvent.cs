﻿using NSW.EliteDangerous.Events.Entities;
using NSW.EliteDangerous.Internals;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class CrimeVictimEvent : JournalEvent
    {
        [JsonProperty("Offender")]
        public string Offender { get; internal set; }

        [JsonProperty("CrimeType")]
        public CrimeType CrimeType { get; internal set; }

        [JsonProperty("Bounty")]
        public long Bounty { get; internal set; }

        internal static CrimeVictimEvent Execute(string json, EliteDangerousAPI api) => api.Combat.InvokeEvent(JsonHelper.FromJson<CrimeVictimEvent>(json));
    }
}