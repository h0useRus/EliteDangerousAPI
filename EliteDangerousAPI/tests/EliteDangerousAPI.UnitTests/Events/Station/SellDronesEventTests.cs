using System;
using System.Collections.Generic;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class SellDronesEventTests
    {
        private const string EventName = "SellDrones";

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
                Assert.Equal(typeof(SellDronesEvent), e.EventType);
                Assert.IsType<SellDronesEvent>(e.Event);
                AssertEvent((SellDronesEvent)e.Event);
                globalFired = true;
            };

            api.Station.SellDrones += (sender, @event) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as SellDronesEvent);
            Assert.True(eventFired, $"Event {EventName} is not thrown");
            Assert.True(globalFired, "Global event is not thrown");
        }

        private static void AssertEvent(SellDronesEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2019-09-02T23:46:31Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal(200, @event.TotalSale);
            Assert.Equal("Drones", @event.Type);
            Assert.Equal(2, @event.Count);
            Assert.Equal(100, @event.SellPrice);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2019-09-02T23:46:31Z\", \"event\":\"SellDrones\", \"Type\":\"Drones\", \"Count\":2, \"SellPrice\":100, \"TotalSale\":200 }" }
            };
    }
}