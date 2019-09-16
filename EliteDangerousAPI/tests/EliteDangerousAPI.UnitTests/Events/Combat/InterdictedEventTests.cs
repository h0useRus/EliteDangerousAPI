using System;
using System.Collections.Generic;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class InterdictedEventTests
    {
        private const string EventName = "Interdicted";

        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = new EliteDangerousAPI();
            var eventFired = false;
            api.Combat.Interdicted += (sender, @event) =>
            {
                Assert.IsType<EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as InterdictedEvent);
            Assert.True(eventFired);
        }

        private void AssertEvent(InterdictedEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2019-09-09T13:41:55Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal("Wiltaim The Lame", @event.Interdictor);
            Assert.Equal("Green Party of Siksikas", @event.Faction);
            Assert.False(@event.Submitted);
            Assert.False(@event.IsPlayer);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2019-09-09T13:41:55Z\", \"event\":\"Interdicted\", \"Submitted\":false, \"Interdictor\":\"Wiltaim The Lame\", \"IsPlayer\":false, \"Faction\":\"Green Party of Siksikas\" }" },
            };
    }
}