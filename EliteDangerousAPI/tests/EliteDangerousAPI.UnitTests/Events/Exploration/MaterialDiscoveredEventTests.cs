using System;
using System.Collections.Generic;
using NSW.EliteDangerous.Events.Entities;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class MaterialDiscoveredEventTests
    {
        private const string EventName = "MaterialDiscovered";

        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = new EliteDangerousAPI();
            var eventFired = false;
            api.Exploration.MaterialDiscovered += (sender, @event) =>
            {
                Assert.IsType<EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as MaterialDiscoveredEvent);
            Assert.True(eventFired, "Event is not thrown");
        }

        private void AssertEvent(MaterialDiscoveredEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2019-09-11T13:04:28Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal(MaterialCategory.Encoded, @event.Category);
            Assert.Equal("encryptioncodes", @event.Name);
            Assert.Equal("Меченые шифровальные коды", @event.NameLocalised);
            Assert.Equal(13, @event.DiscoveryNumber);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2019-09-11T13:04:28Z\", \"event\":\"MaterialDiscovered\", \"Category\":\"Encoded\", \"Name\":\"encryptioncodes\", \"Name_Localised\":\"Меченые шифровальные коды\", \"DiscoveryNumber\":13 }" },
            };
    }
}