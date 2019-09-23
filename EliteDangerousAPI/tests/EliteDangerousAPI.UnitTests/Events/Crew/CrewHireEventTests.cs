using System;
using System.Collections.Generic;
using NSW.EliteDangerous.Events.Entities;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class CrewHireEventTests
    {
        private const string EventName = "CrewHire";

        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = (API.EliteDangerousAPI)TestHelpers.TestApi;
            var eventFired = false;
            api.Crew.CrewHire += (sender, @event) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as CrewHireEvent);
            Assert.True(eventFired, $"Event {EventName} is not thrown");
        }

        private static void AssertEvent(CrewHireEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2016-08-09T08:46:29Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal("Margaret Parrish", @event.Name);
            Assert.Equal(0, @event.CrewId);
            Assert.Equal("The Dark Wheel", @event.Faction);
            Assert.Equal(15000, @event.Cost);
            Assert.Equal(CombatRank.MostlyHarmless, @event.CombatRank);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2016-08-09T08:46:29Z\", \"event\":\"CrewHire\", \"Name\":\"Margaret Parrish\", \"Faction\":\"The Dark Wheel\", \"Cost\":15000, \"CombatRank\":1 } " },
            };
    }
}