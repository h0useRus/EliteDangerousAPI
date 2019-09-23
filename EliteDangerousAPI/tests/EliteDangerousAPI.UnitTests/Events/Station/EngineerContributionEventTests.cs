using System;
using System.Collections.Generic;
using NSW.EliteDangerous.API;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class EngineerContributionEventTests
    {
        private const string EventName = "EngineerContribution";

        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = (API.EliteDangerousAPI)TestHelpers.TestApi;
            var eventFired = false;
            api.Station.EngineerContribution += (sender, @event) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as EngineerContributionEvent);
            Assert.True(eventFired, $"Event {EventName} is not thrown");
        }

        private static void AssertEvent(EngineerContributionEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2019-09-09T12:38:34Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal(300080, @event.EngineerId);
            Assert.Equal("Liz Ryder", @event.Engineer);
            Assert.Equal(ContributionType.Commodity, @event.Type);
            Assert.Equal("landmines", @event.Commodity);
            Assert.Equal("Мины", @event.CommodityLocalised);
            Assert.Equal(46, @event.Quantity);
            Assert.Equal(146, @event.TotalQuantity);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2019-09-09T12:38:34Z\", \"event\":\"EngineerContribution\", \"Engineer\":\"Liz Ryder\", \"EngineerID\":300080, \"Type\":\"Commodity\", \"Commodity\":\"landmines\", \"Commodity_Localised\":\"Мины\", \"Quantity\":46, \"TotalQuantity\":146 }" },
            };
    }
}