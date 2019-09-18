using System;
using System.Collections.Generic;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class FactionKillBondEventTests
    {
        private const string EventName = "FactionKillBond";

        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = (EliteDangerousAPI)TestHelpers.TestApi;
            var eventFired = false;
            api.Combat.FactionKillBond += (sender, @event) =>
            {
                Assert.IsType<EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as FactionKillBondEvent);
            Assert.True(eventFired);
        }

        private void AssertEvent(FactionKillBondEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2016-06-10T14:32:03Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal(500, @event.Reward);
            Assert.Equal("Jarildekald Public Industry", @event.AwardingFaction);
            Assert.Equal("Lencali Freedom Party", @event.VictimFaction);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{\"timestamp\":\"2016-06-10T14:32:03Z\", \"event\":\"FactionKillBond\", \"Reward\": 500,\r\n\"AwardingFaction\":\"Jarildekald Public Industry\", \"VictimFaction\": \"Lencali Freedom Party\" } " },
            };
    }
}