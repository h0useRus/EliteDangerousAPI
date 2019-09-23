using System;
using System.Collections.Generic;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class SupercruiseEntryEventTests
    {
        private const string EventName = "SupercruiseEntry";

        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = (API.EliteDangerousAPI)TestHelpers.TestApi;
            var eventFired = false;
            api.Travel.SupercruiseEntry += (sender, @event) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as SupercruiseEntryEvent);
            Assert.True(eventFired);
        }

        private void AssertEvent(SupercruiseEntryEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2019-09-08T10:17:43Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal("Scylla", @event.StarSystem);
            Assert.Equal(2008064955082, @event.SystemAddress);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2019-09-08T10:17:43Z\", \"event\":\"SupercruiseEntry\", \"StarSystem\":\"Scylla\", \"SystemAddress\":2008064955082 }" },
            };
    }
}