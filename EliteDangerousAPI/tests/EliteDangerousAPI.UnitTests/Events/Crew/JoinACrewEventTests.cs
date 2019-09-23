using System;
using System.Collections.Generic;
using NSW.EliteDangerous.API.Events;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class JoinACrewEventTests
    {
        private const string EventName = "JoinACrew";

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
                Assert.Equal(typeof(JoinACrewEvent), e.EventType);
                Assert.IsType<JoinACrewEvent>(e.Event);
                AssertEvent((JoinACrewEvent)e.Event);
                globalFired = true;
            };

            api.Crew.JoinACrew += (sender, @event) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as JoinACrewEvent);
            Assert.True(eventFired, $"Event {EventName} is not thrown");
            Assert.True(globalFired, "Global event is not thrown");
        }

        private void AssertEvent(JoinACrewEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2016-06-10T14:32:03Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal("John Andersson", @event.Captain);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2016-06-10T14:32:03Z\", \"event\":\"JoinACrew\", \"Captain\":\"John Andersson\" }" },
            };
    }
}