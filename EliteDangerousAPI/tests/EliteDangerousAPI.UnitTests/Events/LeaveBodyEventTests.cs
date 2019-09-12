using System;
using System.Collections.Generic;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class LeaveBodyEventTests
    {
        private const string EventName = "LeaveBody";

        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = new EliteDangerousAPI();
            var eventFired = false;
            api.Travel.LeaveBody += (sender, @event) =>
            {
                Assert.IsType<EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as LeaveBodyEvent);
            Assert.True(eventFired);
        }

        private void AssertEvent(LeaveBodyEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2019-09-07T12:57:42Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal("Eurybia", @event.StarSystem);
            Assert.Equal(1458309141194, @event.SystemAddress);
            Assert.Equal("Makalu", @event.Body);
            Assert.Equal(6, @event.BodyId);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2019-09-07T12:57:42Z\", \"event\":\"LeaveBody\", \"StarSystem\":\"Eurybia\", \"SystemAddress\":1458309141194, \"Body\":\"Makalu\", \"BodyID\":6 }" },
            };
    }
}