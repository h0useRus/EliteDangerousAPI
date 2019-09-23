using System;
using System.Collections.Generic;
using NSW.EliteDangerous.Events.Entities;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class ScannedEventTests
    {
        private const string EventName = "Scanned";

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
                Assert.Equal(typeof(ScannedEvent), e.EventType);
                Assert.IsType<ScannedEvent>(e.Event);
                AssertEvent((ScannedEvent)e.Event);
                globalFired = true;
            };

            api.Ship.Scanned += (sender, @event) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as ScannedEvent);
            Assert.True(eventFired, $"Event {EventName} is not thrown");
            Assert.True(globalFired, "Global event is not thrown");
        }

        private void AssertEvent(ScannedEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2019-08-29T13:34:47Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal(ShipScanType.Cargo, @event.ScanType);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2019-08-29T13:34:47Z\", \"event\":\"Scanned\", \"ScanType\":\"Cargo\" }" },
            };
    }
}