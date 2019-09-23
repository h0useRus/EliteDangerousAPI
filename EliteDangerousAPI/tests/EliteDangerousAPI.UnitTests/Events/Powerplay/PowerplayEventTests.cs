using System;
using System.Collections.Generic;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class PowerplayEventTests
    {
        private const string EventName = "Powerplay";

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
                Assert.Equal(typeof(PowerplayEvent), e.EventType);
                Assert.IsType<PowerplayEvent>(e.Event);
                AssertEvent((PowerplayEvent)e.Event);
                globalFired = true;
            };

            api.Powerplay.Powerplay += (sender, @event) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as PowerplayEvent);
            Assert.True(eventFired, $"Event {EventName} is not thrown");
            Assert.True(globalFired, "Global event is not thrown");
        }

        private void AssertEvent(PowerplayEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2018-01-31T10:53:04Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal("Edmund Mahon", @event.Power);
            Assert.Equal(1, @event.Rank);
            Assert.Equal(10, @event.Merits);
            Assert.Equal(5, @event.Votes);
            Assert.Equal(433024, @event.TimePledged);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2018-01-31T10:53:04Z\", \"event\":\"Powerplay\", \"Power\":\"Edmund Mahon\", \"Rank\":1,\r\n\"Merits\":10, \"Votes\":5, \"TimePledged\":433024 }" },
            };
    }
}