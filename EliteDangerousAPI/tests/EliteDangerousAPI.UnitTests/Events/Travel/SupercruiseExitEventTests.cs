using System;
using System.Collections.Generic;
using NSW.EliteDangerous.API;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class SupercruiseExitEventTests
    {
        private const string EventName = "SupercruiseExit";

        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = (API.EliteDangerousAPI)TestHelpers.TestApi;
            var eventFired = false;
            api.Travel.SupercruiseExit += (sender, @event) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as SupercruiseExitEvent);
            Assert.True(eventFired);
        }

        private void AssertEvent(SupercruiseExitEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2019-09-08T10:20:27Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal("Scylla", @event.StarSystem);
            Assert.Equal(2008064955082, @event.SystemAddress);
            Assert.Equal("Nagel City", @event.Body);
            Assert.Equal(58, @event.BodyId);
            Assert.Equal(BodyType.Station, @event.BodyType);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2019-09-08T10:20:27Z\", \"event\":\"SupercruiseExit\", \"StarSystem\":\"Scylla\", \"SystemAddress\":2008064955082, \"Body\":\"Nagel City\", \"BodyID\":58, \"BodyType\":\"Station\" }" },
            };
    }
}