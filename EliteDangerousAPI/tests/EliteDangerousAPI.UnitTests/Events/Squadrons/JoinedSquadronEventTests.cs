using System;
using System.Collections.Generic;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class InvitedToSquadronEventTests
    {
        private const string EventName = "InvitedToSquadron";

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
                Assert.Equal(typeof(InvitedToSquadronEvent), e.EventType);
                Assert.IsType<InvitedToSquadronEvent>(e.Event);
                AssertEvent((InvitedToSquadronEvent)e.Event);
                globalFired = true;
            };

            api.Squadron.InvitedToSquadron += (sender, @event) =>
            {
                Assert.IsType<EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as InvitedToSquadronEvent);
            Assert.True(eventFired, $"Event {EventName} is not thrown");
            Assert.True(globalFired, "Global event is not thrown");
        }

        private void AssertEvent(InvitedToSquadronEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2018-10-17T16:17:55Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal("TestSquadron", @event.SquadronName);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2018-10-17T16:17:55Z\", \"event\":\"InvitedToSquadron\", \"SquadronName\":\"TestSquadron\" }" },
            };
    }
}