using System;
using System.Collections.Generic;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class ResurrectEventTests
    {
        private const string EventName = "Resurrect";

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
                Assert.Equal(typeof(ResurrectEvent), e.EventType);
                Assert.IsType<ResurrectEvent>(e.Event);
                AssertEvent((ResurrectEvent)e.Event);
                globalFired = true;
            };

            api.Player.Resurrect += (sender, @event) =>
            {
                Assert.IsType<EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as ResurrectEvent);
            Assert.True(eventFired, $"Event {EventName} is not thrown");
            Assert.True(globalFired, "Global event is not thrown");
        }

        private void AssertEvent(ResurrectEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2019-09-04T14:31:07Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal("rebuy", @event.Option);
            Assert.Equal(106164, @event.Cost);
            Assert.False(@event.Bankrupt);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2019-09-04T14:31:07Z\", \"event\":\"Resurrect\", \"Option\":\"rebuy\", \"Cost\":106164, \"Bankrupt\":false }" },
            };
    }
}