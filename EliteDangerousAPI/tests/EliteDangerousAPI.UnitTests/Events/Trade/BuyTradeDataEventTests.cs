using System;
using System.Collections.Generic;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class BuyTradeDataEventTests
    {
        private const string EventName = "BuyTradeData";

        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = new EliteDangerousAPI();
            var eventFired = false;
            api.Trade.BuyTradeData += (sender, @event) =>
            {
                Assert.IsType<EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as BuyTradeDataEvent);
            Assert.True(eventFired, "Event is not thrown");
        }

        private void AssertEvent(BuyTradeDataEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2016-06-10T14:32:03Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal("i Bootis", @event.System);
            Assert.Equal(100, @event.Cost);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2016-06-10T14:32:03Z\", \"event\":\"BuyTradeData\", \"System\":\"i Bootis\", \"Cost\":100 } " },
            };
    }
}