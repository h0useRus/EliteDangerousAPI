using System;
using System.Collections.Generic;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class JetConeDamageEventTests
    {
        private const string EventName = "JetConeDamage";

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
                Assert.Equal(typeof(JetConeDamageEvent), e.EventType);
                Assert.IsType<JetConeDamageEvent>(e.Event);
                AssertEvent((JetConeDamageEvent)e.Event);
                globalFired = true;
            };

            api.Ship.JetConeDamage += (sender, @event) =>
            {
                Assert.IsType<EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as JetConeDamageEvent);
            Assert.True(eventFired, $"Event {EventName} is not thrown");
            Assert.True(globalFired, "Global event is not thrown");
        }

        private void AssertEvent(JetConeDamageEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2017-08-14T15:41:50Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal("$modularcargobaydoor_name;", @event.Module);
            Assert.Equal("Cargo Hatch", @event.ModuleLocalised);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2017-08-14T15:41:50Z\", \"event\":\"JetConeDamage\",\"Module\":\"$modularcargobaydoor_name;\", \"Module_Localised\":\"Cargo Hatch\" }" },
            };
    }
}