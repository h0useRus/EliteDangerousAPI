using System;
using System.Collections.Generic;
using NSW.EliteDangerous.API;
using NSW.EliteDangerous.API.Events;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class SetUserShipNameEventTests
    {
        private const string EventName = "SetUserShipName";

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
                Assert.Equal(typeof(SetUserShipNameEvent), e.EventType);
                Assert.IsType<SetUserShipNameEvent>(e.Event);
                AssertEvent((SetUserShipNameEvent)e.Event);
                globalFired = true;
            };

            api.StationEvents.SetUserShipName += (sender, @event) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as SetUserShipNameEvent);
            Assert.True(eventFired, $"Event {EventName} is not thrown");
            Assert.True(globalFired, "Global event is not thrown");
        }

        private static void AssertEvent(SetUserShipNameEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2019-08-29T14:14:38Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal(ShipType.Sidewinder, @event.ShipType);
            Assert.Equal(0, @event.ShipId);
            Assert.Equal("Manta", @event.UserShipName);
            Assert.Equal("NSW-01", @event.UserShipId);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2019-08-29T14:14:38Z\", \"event\":\"SetUserShipName\", \"Ship\":\"sidewinder\", \"ShipID\":0, \"UserShipName\":\"Manta\", \"UserShipId\":\"NSW-01\" }" }
            };
    }
}