using System;
using System.Collections.Generic;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class DiscoveryScanEventTests
    {
         private const string EventName = "DiscoveryScan";

        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = new EliteDangerousAPI();
            var eventFired = false;
            api.Exploration.DiscoveryScan += (sender, @event) =>
            {
                Assert.IsType<EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as DiscoveryScanEvent);
            Assert.True(eventFired);
        }

        private void AssertEvent(DiscoveryScanEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2019-09-11T11:37:07Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            // TODO: Add more tests
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2019-09-11T11:37:07Z\", \"event\":\"DiscoveryScan\" }" },
            };
    }
}