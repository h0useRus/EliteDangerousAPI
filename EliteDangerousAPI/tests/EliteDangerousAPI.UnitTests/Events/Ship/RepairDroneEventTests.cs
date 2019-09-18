using System;
using System.Collections.Generic;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class RepairDroneEventTests
    {
        private const string EventName = "RepairDrone";

        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = (EliteDangerousAPI)TestHelpers.TestApi;
            var globalFired = false;
            var eventFired = false;

            api.AllEvents += (s, e) =>
            {
                Assert.IsType<EliteDangerousAPI>(s);
                Assert.Equal(EventName.ToLower(), e.EventName);
                Assert.Equal(typeof(RepairDroneEvent), e.EventType);
                Assert.IsType<RepairDroneEvent>(e.Event);
                AssertEvent((RepairDroneEvent)e.Event);
                globalFired = true;
            };

            api.Ship.RepairDrone += (sender, @event) =>
            {
                Assert.IsType<EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as RepairDroneEvent);
            Assert.True(eventFired, $"Event {EventName} is not thrown");
            Assert.True(globalFired, "Global event is not thrown");
        }

        private void AssertEvent(RepairDroneEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2017-08-14T15:41:50Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal(1.000000, @event.CockpitRepaired, 6);
            Assert.Equal(1.000000, @event.CorrosionRepaired, 6);
            Assert.Equal(1.000000, @event.HullRepaired, 6);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2017-08-14T15:41:50Z\", \"event\":\"RepairDrone\",\"CockpitRepaired\":1.000000, \"CorrosionRepaired\":1.000000, \"HullRepaired\":1.000000 }" },
            };
    }
}