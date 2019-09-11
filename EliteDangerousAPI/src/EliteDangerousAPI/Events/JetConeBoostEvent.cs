﻿using NSW.EliteDangerous.Internals;
using Newtonsoft.Json;

namespace NSW.EliteDangerous.Events
{
    public class JetConeBoostEvent : JournalEvent
    {
        [JsonProperty("BoostValue")]
        public double BoostValue { get; internal set; }

        internal static JetConeBoostEvent Execute(string json, EliteDangerousAPI api) => api.Ship.InvokeEvent(JsonHelper.FromJson<JetConeBoostEvent>(json));
    }
}