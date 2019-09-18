using System;
using System.Collections.Generic;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class CollectCargoEventTests
    {
        private const string EventName = "CollectCargo";

        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = (EliteDangerousAPI)TestHelpers.TestApi;
            var eventFired = false;
            api.Trade.CollectCargo += (sender, @event) =>
            {
                Assert.IsType<EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as CollectCargoEvent);
            Assert.True(eventFired, "Event is not thrown");
        }

        private void AssertEvent(CollectCargoEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2019-08-30T12:10:19Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal("Clothing", @event.Type);
            Assert.Equal("Одежда", @event.TypeLocalised);
            Assert.True(@event.Stolen);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2019-08-30T12:10:19Z\", \"event\":\"CollectCargo\", \"Type\":\"Clothing\", \"Type_Localised\":\"Одежда\", \"Stolen\":true }" },
            };
    }
}