using System;
using System.Collections.Generic;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class FighterRebuiltEventTests
    {
        private const string EventName = "FighterRebuilt";

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
                Assert.Equal(typeof(FighterRebuiltEvent), e.EventType);
                Assert.IsType<FighterRebuiltEvent>(e.Event);
                AssertEvent((FighterRebuiltEvent)e.Event);
                globalFired = true;
            };

            api.Ship.FighterRebuilt += (sender, @event) =>
            {
                Assert.IsType<EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as FighterRebuiltEvent);
            Assert.True(eventFired, $"Event {EventName} is not thrown");
            Assert.True(globalFired, "Global event is not thrown");
        }

        private void AssertEvent(FighterRebuiltEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2017-08-14T15:41:50Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal("Loadout 1", @event.Loadout);
            Assert.Equal(2, @event.Id);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2017-08-14T15:41:50Z\", \"event\":\"FighterRebuilt\", \"Loadout\":\"Loadout 1\", \"ID\":2 }" },
            };
    }
}