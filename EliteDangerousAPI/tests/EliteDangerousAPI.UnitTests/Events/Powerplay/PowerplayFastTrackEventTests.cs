using System;
using System.Collections.Generic;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class PowerplayFastTrackEventTests
    {
        private const string EventName = "PowerplayFastTrack";

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
                Assert.Equal(typeof(PowerplayFastTrackEvent), e.EventType);
                Assert.IsType<PowerplayFastTrackEvent>(e.Event);
                AssertEvent((PowerplayFastTrackEvent)e.Event);
                globalFired = true;
            };

            api.Powerplay.PowerplayFastTrack += (sender, @event) =>
            {
                Assert.IsType<EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as PowerplayFastTrackEvent);
            Assert.True(eventFired, $"Event {EventName} is not thrown");
            Assert.True(globalFired, "Global event is not thrown");
        }

        private void AssertEvent(PowerplayFastTrackEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2016-06-10T14:32:03Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal("Li Yong-Rui", @event.Power);
            Assert.Equal(10, @event.Cost);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2016-06-10T14:32:03Z\", \"event\":\"PowerplayFastTrack\", \"Power\":\"Li Yong-Rui\", \"Cost\":10 }" },
            };
    }
}