using System;
using System.Collections.Generic;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class EscapeInterdictionEventTests
    {
        private const string EventName = "EscapeInterdiction";

        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = new EliteDangerousAPI();
            var eventFired = false;
            api.Combat.EscapeInterdiction += (sender, @event) =>
            {
                Assert.IsType<EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as EscapeInterdictionEvent);
            Assert.True(eventFired);
        }

        private void AssertEvent(EscapeInterdictionEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2019-09-05T11:51:11Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal("Thiery", @event.Interdictor);
            Assert.True(@event.IsPlayer);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2019-09-05T11:51:11Z\", \"event\":\"EscapeInterdiction\", \"Interdictor\":\"Thiery\", \"IsPlayer\":true }" },
            };
    }
}