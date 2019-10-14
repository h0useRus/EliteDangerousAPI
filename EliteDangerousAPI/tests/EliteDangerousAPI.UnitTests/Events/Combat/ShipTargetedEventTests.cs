using System;
using System.Collections.Generic;
using NSW.EliteDangerous.API;
using NSW.EliteDangerous.API.Events;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class ShipTargetedEventTests
    {
        private const string EventName = "ShipTargeted";

        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = (API.EliteDangerousAPI)TestHelpers.TestApi;
            var eventFired = false;
            api.CombatEvents.ShipTargeted += (sender, @event) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as ShipTargetedEvent);
            Assert.True(eventFired);
        }

        private void AssertEvent(ShipTargetedEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2019-09-11T11:05:29Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal(3, @event.ScanStage);
            Assert.Equal("federation_fighter", @event.ShipType);
            Assert.Equal(ShipModel.Npc, @event.ShipModel);
            Assert.Equal("F63 Condor", @event.ShipLocalised);
            Assert.Equal("$ShipName_Police_Federation;", @event.PilotName);
            Assert.Equal("Федеральная служба безопасности", @event.PilotNameLocalised);
            Assert.Equal(CombatRank.MostlyHarmless, @event.PilotRank);
            Assert.Equal("Independent HIP 29241 Green Party", @event.Faction);
            Assert.Equal("Clean", @event.LegalStatus);
            Assert.Equal(100.000000, @event.ShieldHealth, 6);
            Assert.Equal(100.000000, @event.HullHealth, 6);
            Assert.True(@event.TargetLocked);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2019-09-11T11:05:29Z\", \"event\":\"ShipTargeted\", \"TargetLocked\":true, \"Ship\":\"federation_fighter\", \"Ship_Localised\":\"F63 Condor\", \"ScanStage\":3, \"PilotName\":\"$ShipName_Police_Federation;\", \"PilotName_Localised\":\"Федеральная служба безопасности\", \"PilotRank\":\"Mostly Harmless\", \"ShieldHealth\":100.000000, \"HullHealth\":100.000000, \"Faction\":\"Independent HIP 29241 Green Party\", \"LegalStatus\":\"Clean\" }" },
            };
    }
}