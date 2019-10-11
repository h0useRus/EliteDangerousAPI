using System;
using System.Collections.Generic;
using NSW.EliteDangerous.API;
using NSW.EliteDangerous.API.Events;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class ShipyardNewEventTests
    {
        private const string EventName = "ShipyardNew";

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
                Assert.Equal(typeof(ShipyardNewEvent), e.EventType);
                Assert.IsType<ShipyardNewEvent>(e.Event);
                AssertEvent((ShipyardNewEvent)e.Event);
                globalFired = true;
            };

            api.StationEvents.ShipyardNew += (sender, @event) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as ShipyardNewEvent);
            Assert.True(eventFired, $"Event {EventName} is not thrown");
            Assert.True(globalFired, "Global event is not thrown");
        }

        private static void AssertEvent(ShipyardNewEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2019-08-30T14:10:32Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal(ShipType.Adder, @event.ShipType);
            Assert.Equal(2, @event.NewShipId);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2019-08-30T14:10:32Z\", \"event\":\"ShipyardNew\", \"ShipType\":\"adder\", \"NewShipID\":2 }" }
            };
    }
}