using System;
using System.Collections.Generic;
using NSW.EliteDangerous.API;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class LaunchDroneEventTests
    {
        private const string EventName = "LaunchDrone";

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
                Assert.Equal(typeof(LaunchDroneEvent), e.EventType);
                Assert.IsType<LaunchDroneEvent>(e.Event);
                AssertEvent((LaunchDroneEvent)e.Event);
                globalFired = true;
            };

            api.Ship.LaunchDrone += (sender, @event) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as LaunchDroneEvent);
            Assert.True(eventFired, $"Event {EventName} is not thrown");
            Assert.True(globalFired, "Global event is not thrown");
        }

        private void AssertEvent(LaunchDroneEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2017-08-14T15:41:50Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal(DroneMission.Collection, @event.Type);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2017-08-14T15:41:50Z\", \"event\":\"LaunchDrone\",\"Type\":\"Collection\" }" }
            };
    }
}