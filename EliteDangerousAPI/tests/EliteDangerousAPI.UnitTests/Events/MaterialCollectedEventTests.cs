using System;
using System.Collections.Generic;
using NSW.EliteDangerous.Events.Entities;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class MaterialCollectedEventTests
    {
        private const string EventName = "MaterialCollected";

        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = new EliteDangerousAPI();
            var eventFired = false;
            api.Exploration.MaterialCollected += (sender, @event) =>
            {
                Assert.IsType<EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as MaterialCollectedEvent);
            Assert.True(eventFired);
        }

        private void AssertEvent(MaterialCollectedEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2016-06-10T14:32:03Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal(MaterialCategory.Encoded, @event.Category);
            Assert.Equal("disruptedwakeechoes", @event.Name);
            Assert.Equal(1, @event.Count);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2016-06-10T14:32:03Z\", \"event\":\"MaterialCollected\", \"Category\":\"Encoded\", \"Name\":\"disruptedwakeechoes\", \"Count\":1 } " },
            };
    }
}