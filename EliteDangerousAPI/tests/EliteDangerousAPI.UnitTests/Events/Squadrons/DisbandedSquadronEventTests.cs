using System;
using System.Collections.Generic;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class DisbandedSquadronEventTests
    {
        private const string EventName = "DisbandedSquadron";

        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = new EliteDangerousAPI();
            var globalFired = false;
            var eventFired = false;

            api.AllEvents += (s, e) =>
            {
                Assert.IsType<EliteDangerousAPI>(s);
                Assert.Equal(EventName.ToLower(), e.EventName);
                Assert.Equal(typeof(DisbandedSquadronEvent), e.EventType);
                Assert.IsType<DisbandedSquadronEvent>(e.Event);
                AssertEvent((DisbandedSquadronEvent)e.Event);
                globalFired = true;
            };

            api.Squadron.DisbandedSquadron += (sender, @event) =>
            {
                Assert.IsType<EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as DisbandedSquadronEvent);
            Assert.True(eventFired, $"Event {EventName} is not thrown");
            Assert.True(globalFired, "Global event is not thrown");
        }

        private void AssertEvent(DisbandedSquadronEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2018-10-17T16:17:55Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal("TestSquadron", @event.SquadronName);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2018-10-17T16:17:55Z\", \"event\":\"DisbandedSquadron\", \"SquadronName\":\"TestSquadron\" }" },
            };
    }
}