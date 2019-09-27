using System;
using System.Collections.Generic;
using NSW.EliteDangerous.API.Events;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class TouchdownEventTests
    {
        private const string EventName = "Touchdown";

        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = (API.EliteDangerousAPI)TestHelpers.TestApi;
            var eventFired = false;
            api.TravelEvents.Touchdown += (sender, @event) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as TouchdownEvent);
            Assert.True(eventFired);
        }

        private void AssertEvent(TouchdownEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2016-07-22T10:53:19Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal(63.468872, @event.Latitude, 6);
            Assert.Equal(157.599380, @event.Longitude);
            Assert.True(@event.PlayerControlled);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2016-07-22T10:53:19Z\", \"event\":\"Touchdown\", \"Latitude\":63.468872, \"Longitude\":157.599380, \"PlayerControlled\":true }" },
            };
    }
}