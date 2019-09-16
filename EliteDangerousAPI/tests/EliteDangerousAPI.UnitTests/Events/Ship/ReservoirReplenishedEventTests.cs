using System;
using System.Collections.Generic;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class ReservoirReplenishedEventTests
    {
        private const string EventName = "ReservoirReplenished";

        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = new EliteDangerousAPI();
            var globalFired = false;
            var eventFired = false;

            api.AllEvents += (s, e) =>
            {
                Assert.IsType<EliteDangerousAPI>(s);
                Assert.Equal(EventName.ToLower(), e.EventName);
                Assert.Equal(typeof(ReservoirReplenishedEvent), e.EventType);
                Assert.IsType<ReservoirReplenishedEvent>(e.Event);
                AssertEvent((ReservoirReplenishedEvent)e.Event);
                globalFired = true;
            };

            api.Ship.ReservoirReplenished += (sender, @event) =>
            {
                Assert.IsType<EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as ReservoirReplenishedEvent);
            Assert.True(eventFired, $"Event {EventName} is not thrown");
            Assert.True(globalFired, "Global event is not thrown");
        }

        private void AssertEvent(ReservoirReplenishedEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2019-08-29T12:09:52Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal(1.145758, @event.FuelMain, 6);
            Assert.Equal(0.300000, @event.FuelReservoir, 6);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2019-08-29T12:09:52Z\", \"event\":\"ReservoirReplenished\", \"FuelMain\":1.145758, \"FuelReservoir\":0.300000 }" },
            };
    }
}