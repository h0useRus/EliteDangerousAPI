using System;
using System.Collections.Generic;
using NSW.EliteDangerous.API;
using NSW.EliteDangerous.API.Events;
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
            var api = (API.EliteDangerousAPI)TestHelpers.TestApi;
            var eventFired = false;
            api.ExplorationEvents.MaterialCollected += (sender, @event) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(sender);
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
            Assert.Equal(DateTime.Parse("2019-09-11T11:30:48Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal(MaterialCategory.Manufactured, @event.Category);
            Assert.Equal("fedcorecomposites", @event.Name);
            Assert.Equal("Композиты Core Dynamics", @event.NameLocalised);
            Assert.Equal(3, @event.Count);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2019-09-11T11:30:48Z\", \"event\":\"MaterialCollected\", \"Category\":\"Manufactured\", \"Name\":\"fedcorecomposites\", \"Name_Localised\":\"Композиты Core Dynamics\", \"Count\":3 }" },
            };
    }
}