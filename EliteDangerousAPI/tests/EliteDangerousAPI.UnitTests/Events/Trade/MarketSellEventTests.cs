using System;
using System.Collections.Generic;
using NSW.EliteDangerous.API.Events;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class MarketSellEventTests
    {
        private const string EventName = "MarketSell";

        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = (API.EliteDangerousAPI)TestHelpers.TestApi;
            var eventFired = false;
            api.TradeEvents.MarketSell += (sender, @event) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as MarketSellEvent);
            Assert.True(eventFired, "Event is not thrown");
        }

        private void AssertEvent(MarketSellEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2019-09-07T12:48:50Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal("syntheticfabrics", @event.Type);
            Assert.Equal("Синтетическая ткань", @event.TypeLocalised);
            Assert.Equal(3511645184, @event.MarketId);
            Assert.Equal(44, @event.Count);
            Assert.Equal(4204, @event.SellPrice);
            Assert.Equal(184976, @event.TotalSale);
            Assert.Equal(0, @event.AvgPricePaid);
            Assert.True(@event.StolenGoods);
            Assert.True(@event.BlackMarket);
            Assert.False(@event.IllegalGoods);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2019-09-07T12:48:50Z\", \"event\":\"MarketSell\", \"MarketID\":3511645184, \"Type\":\"syntheticfabrics\", \"Type_Localised\":\"Синтетическая ткань\", \"Count\":44, \"SellPrice\":4204, \"TotalSale\":184976, \"AvgPricePaid\":0, \"StolenGoods\":true, \"BlackMarket\":true }" },
            };
    }
}