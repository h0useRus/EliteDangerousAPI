using System;
using System.Collections.Generic;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class RestockVehicleEventTests
    {
        private const string EventName = "RestockVehicle";

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
                Assert.Equal(typeof(RestockVehicleEvent), e.EventType);
                Assert.IsType<RestockVehicleEvent>(e.Event);
                AssertEvent((RestockVehicleEvent)e.Event);
                globalFired = true;
            };

            api.Station.RestockVehicle += (sender, @event) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as RestockVehicleEvent);
            Assert.True(eventFired, $"Event {EventName} is not thrown");
            Assert.True(globalFired, $"Global event is not thrown");
        }

        private static void AssertEvent(RestockVehicleEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2016-06-10T14:32:03Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal("SRV", @event.Type);
            Assert.Equal("starter", @event.Loadout);
            Assert.Equal(1030, @event.Cost);
            Assert.Equal(1, @event.Count);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2016-06-10T14:32:03Z\", \"event\":\"RestockVehicle\", \"Type\":\"SRV\", \"Loadout\":\"starter\", \"Cost\":1030, \"Count\":1 }" }
            };
    }
}