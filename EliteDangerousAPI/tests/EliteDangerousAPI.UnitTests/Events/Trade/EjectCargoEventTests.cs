using System;
using System.Collections.Generic;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class EjectCargoEventTests
    {
        private const string EventName = "EjectCargo";

        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = (EliteDangerousAPI)TestHelpers.TestApi;
            var eventFired = false;
            api.Trade.EjectCargo += (sender, @event) =>
            {
                Assert.IsType<EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as EjectCargoEvent);
            Assert.True(eventFired, "Event is not thrown");
        }

        private void AssertEvent(EjectCargoEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2019-09-05T11:54:49Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal("tea", @event.Type);
            Assert.Equal("Чай", @event.TypeLocalised);
            Assert.Equal(1, @event.Count);
            Assert.False(@event.Abandoned);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2019-09-05T11:54:49Z\", \"event\":\"EjectCargo\", \"Type\":\"tea\", \"Type_Localised\":\"Чай\", \"Count\":1, \"Abandoned\":false }" },
            };
    }
}