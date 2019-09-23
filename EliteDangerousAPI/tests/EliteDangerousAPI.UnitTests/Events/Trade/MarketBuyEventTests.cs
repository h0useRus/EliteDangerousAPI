using System;
using System.Collections.Generic;
using NSW.EliteDangerous.API.Events;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class MarketBuyEventTests
    {
        private const string EventName = "MarketBuy";

        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = (API.EliteDangerousAPI)TestHelpers.TestApi;
            var eventFired = false;
            api.Trade.MarketBuy += (sender, @event) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as MarketBuyEvent);
            Assert.True(eventFired, "Event is not thrown");
        }

        private void AssertEvent(MarketBuyEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2019-09-09T12:28:25Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal("landmines", @event.Type);
            Assert.Equal("Мины", @event.TypeLocalised);
            Assert.Equal(3510937344, @event.MarketId);
            Assert.Equal(46, @event.Count);
            Assert.Equal(4336, @event.BuyPrice);
            Assert.Equal(199456, @event.TotalCost);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2019-09-09T12:28:25Z\", \"event\":\"MarketBuy\", \"MarketID\":3510937344, \"Type\":\"landmines\", \"Type_Localised\":\"Мины\", \"Count\":46, \"BuyPrice\":4336, \"TotalCost\":199456 }" },
            };
    }
}