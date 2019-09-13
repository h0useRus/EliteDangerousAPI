using System;
using System.Collections.Generic;
using NSW.EliteDangerous.Events.Entities;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class MaterialDiscardedEventTests
    {
        private const string EventName = "MaterialDiscarded";

        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = new EliteDangerousAPI();
            var eventFired = false;
            api.Exploration.MaterialDiscarded += (sender, @event) =>
            {
                Assert.IsType<EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as MaterialDiscardedEvent);
            Assert.True(eventFired, "Event is not thrown");
        }

        private void AssertEvent(MaterialDiscardedEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2019-09-11T11:30:48Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal(MaterialCategory.Raw, @event.Category);
            Assert.Equal("sulphur", @event.Name);
            Assert.Equal("Сера", @event.NameLocalised);
            Assert.Equal(3, @event.Count);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2019-09-11T11:30:48Z\", \"event\":\"MaterialDiscarded\", \"Category\":\"Raw\", \"Name\":\"sulphur\", \"Name_Localised\":\"Сера\", \"Count\":3 }" },
            };
    }
}