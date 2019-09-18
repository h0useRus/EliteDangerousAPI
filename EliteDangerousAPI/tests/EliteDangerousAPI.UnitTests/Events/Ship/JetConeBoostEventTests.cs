using System;
using System.Collections.Generic;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class JetConeBoostEventTests
    {
        private const string EventName = "JetConeBoost";

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
                Assert.Equal(typeof(JetConeBoostEvent), e.EventType);
                Assert.IsType<JetConeBoostEvent>(e.Event);
                AssertEvent((JetConeBoostEvent)e.Event);
                globalFired = true;
            };

            api.Ship.JetConeBoost += (sender, @event) =>
            {
                Assert.IsType<EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as JetConeBoostEvent);
            Assert.True(eventFired, $"Event {EventName} is not thrown");
            Assert.True(globalFired, "Global event is not thrown");
        }

        private void AssertEvent(JetConeBoostEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2017-08-14T15:41:50Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal(1.000000, @event.BoostValue, 6);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2017-08-14T15:41:50Z\", \"event\":\"JetConeBoost\",\"BoostValue\": 1.000000 }" },
            };
    }
}