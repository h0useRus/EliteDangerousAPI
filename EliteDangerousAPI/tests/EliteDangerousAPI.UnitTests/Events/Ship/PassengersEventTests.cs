using System;
using System.Collections.Generic;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class PassengersEventTests
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = new EliteDangerousAPI();
            var eventFired = false;
            api.Ship.Passengers += (sender, @event) =>
            {
                Assert.IsType<EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as PassengersEvent);
            Assert.True(eventFired);
        }

        private void AssertEvent(PassengersEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2016-06-10T14:32:03Z"), @event.Timestamp);
            Assert.Equal("Passengers", @event.Event);
            // TODO: Add more tests
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { "Passengers",  "{ \"timestamp\":\"2016-06-10T14:32:03Z\", \"event\":\"Passengers\" }" },
            };
    }
}