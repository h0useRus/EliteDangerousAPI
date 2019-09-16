using System;
using System.Collections.Generic;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class PowerplayCollectEventTests
    {
        private const string EventName = "PowerplayCollect";

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
                Assert.Equal(typeof(PowerplayCollectEvent), e.EventType);
                Assert.IsType<PowerplayCollectEvent>(e.Event);
                AssertEvent((PowerplayCollectEvent)e.Event);
                globalFired = true;
            };

            api.Powerplay.PowerplayCollect += (sender, @event) =>
            {
                Assert.IsType<EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as PowerplayCollectEvent);
            Assert.True(eventFired, $"Event {EventName} is not thrown");
            Assert.True(globalFired, "Global event is not thrown");
        }

        private void AssertEvent(PowerplayCollectEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2016-06-10T14:32:03Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal("Li Yong-Rui", @event.Power);
            Assert.Equal("siriusfranchisepackage", @event.Type);
            Assert.Equal(10, @event.Count);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2016-06-10T14:32:03Z\", \"event\":\"PowerplayCollect\", \"Power\":\"Li Yong-Rui\", \"Type\":\"siriusfranchisepackage\", \"Count\":10 }" },
            };
    }
}