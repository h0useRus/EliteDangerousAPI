using System;
using System.Collections.Generic;
using NSW.EliteDangerous.API.Events;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class AfmuRepairsEventTests
    {
        private const string EventName = "AfmuRepairs";

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
                Assert.Equal(typeof(AfmuRepairsEvent), e.EventType);
                Assert.IsType<AfmuRepairsEvent>(e.Event);
                AssertEvent((AfmuRepairsEvent)e.Event);
                globalFired = true;
            };

            api.Ship.AfmuRepairs += (sender, @event) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as AfmuRepairsEvent);
            Assert.True(eventFired, $"Event {EventName} is not thrown");
            Assert.True(globalFired, "Global event is not thrown");
        }

        private void AssertEvent(AfmuRepairsEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2017-08-14T15:41:50Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal("$modularcargobaydoor_name;", @event.Module);
            Assert.Equal("Cargo Hatch", @event.ModuleLocalised);
            Assert.True(@event.FullyRepaired);
            Assert.Equal(1.000000, @event.Health, 6);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2017-08-14T15:41:50Z\", \"event\":\"AfmuRepairs\",\"Module\":\"$modularcargobaydoor_name;\", \"Module_Localised\":\"Cargo Hatch\",\"FullyRepaired\":true, \"Health\":1.000000 }" },
            };
    }
}