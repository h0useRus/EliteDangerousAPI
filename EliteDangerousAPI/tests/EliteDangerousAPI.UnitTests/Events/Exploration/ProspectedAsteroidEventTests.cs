using System;
using System.Collections.Generic;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class ProspectedAsteroidEventTests
    {
        private const string EventName = "ProspectedAsteroid";

        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = (API.EliteDangerousAPI)TestHelpers.TestApi;
            var globalFired = false;
            var eventFired = false;

            api.AllEvents += (s, e) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(s);
                Assert.Equal(EventName.ToLower(), e.EventName);
                Assert.Equal(typeof(ProspectedAsteroidEvent), e.EventType);
                Assert.IsType<ProspectedAsteroidEvent>(e.Event);
                AssertEvent((ProspectedAsteroidEvent)e.Event);
                globalFired = true;
            };

            api.Exploration.ProspectedAsteroid += (sender, @event) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as ProspectedAsteroidEvent);
            Assert.True(eventFired, $"Event {EventName} is not thrown");
            Assert.True(globalFired, "Global event is not thrown");
        }

        private void AssertEvent(ProspectedAsteroidEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2019-09-11T13:04:24Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            // TODO: Add more tests
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2019-09-11T13:04:24Z\", \"event\":\"ProspectedAsteroid\" }" },
            };
    }
}