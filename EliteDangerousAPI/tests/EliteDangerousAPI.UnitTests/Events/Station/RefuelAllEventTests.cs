using System;
using System.Collections.Generic;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class RefuelAllEventTests
    {
        private const string EventName = "RefuelAll";

        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = (EliteDangerousAPI)TestHelpers.TestApi;
            var eventFired = false;

            api.AllEvents += (s, e) =>
            {
                Assert.IsType<EliteDangerousAPI>(s);
                Assert.Equal(EventName.ToLower(), e.EventName);
                Assert.Equal(typeof(RefuelAllEvent), e.EventType);
                Assert.IsType<RefuelAllEvent>(e.Event);
            };

            api.Station.RefuelAll += (sender, @event) =>
            {
                Assert.IsType<EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as RefuelAllEvent);
            Assert.True(eventFired, $"Event {EventName} is not thrown");
        }

        private static void AssertEvent(RefuelAllEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2019-09-09T12:03:59Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal(343, @event.Cost);
            Assert.Equal(6.838118, @event.Amount, 6);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2019-09-09T12:03:59Z\", \"event\":\"RefuelAll\", \"Cost\":343, \"Amount\":6.838118 }" }
            };
    }
}