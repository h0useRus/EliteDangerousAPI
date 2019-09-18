using System;
using System.Collections.Generic;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class SquadronStartupEventTests
    {
        private const string EventName = "SquadronStartup";

        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = (EliteDangerousAPI)TestHelpers.TestApi;
            var globalFired = false;
            var eventFired = false;

            api.AllEvents += (s, e) =>
            {
                Assert.IsType<EliteDangerousAPI>(s);
                Assert.Equal(EventName.ToLower(), e.EventName);
                Assert.Equal(typeof(SquadronStartupEvent), e.EventType);
                Assert.IsType<SquadronStartupEvent>(e.Event);
                AssertEvent((SquadronStartupEvent)e.Event);
                globalFired = true;
            };

            api.Squadron.SquadronStartup += (sender, @event) =>
            {
                Assert.IsType<EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as SquadronStartupEvent);
            Assert.True(eventFired, $"Event {EventName} is not thrown");
            Assert.True(globalFired, "Global event is not thrown");
        }

        private void AssertEvent(SquadronStartupEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2018-10-17T16:17:55Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal("TestSquadron", @event.SquadronName);
            Assert.Equal(2, @event.CurrentRank);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2018-10-17T16:17:55Z\", \"event\":\"SquadronStartup\", \"SquadronName\":\"TestSquadron\", \"CurrentRank\":2 }" },
            };
    }
}