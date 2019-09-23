using System;
using System.Collections.Generic;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class MaterialTradeEventTests
    {
        private const string EventName = "MaterialTrade";

        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = (API.EliteDangerousAPI)TestHelpers.TestApi;
            var eventFired = false;
            api.Station.MaterialTrade += (sender, @event) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as MaterialTradeEvent);
            Assert.True(eventFired, $"Event {EventName} is not thrown");
        }

        private static void AssertEvent(MaterialTradeEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2018-02-21T15:23:49Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal(3221397760, @event.MarketId);
            Assert.Equal("encoded", @event.TraderType);
            Assert.Equal("scandatabanks", @event.Paid.Material);
            Assert.Equal("Classified Scan Databanks", @event.Paid.MaterialLocalised);
            Assert.Equal("Encoded", @event.Paid.Category);
            Assert.Equal("Encoded", @event.Paid.CategoryLocalised);
            Assert.Equal(6, @event.Paid.Quantity);
            Assert.Equal("encodedscandata", @event.Received.Material);
            Assert.Equal("Divergent Scan Data", @event.Received.MaterialLocalised);
            Assert.Equal(1, @event.Received.Quantity);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2018-02-21T15:23:49Z\", \"event\":\"MaterialTrade\", \"MarketID\":3221397760,\"TraderType\":\"encoded\", \"Paid\":{ \"Material\":\"scandatabanks\", \"Material_Localised\":\"Classified Scan Databanks\", \"Category\":\"Encoded\", \"Quantity\":6, \"Category_Localised\":\"Encoded\" }, \"Received\":{\"Material\":\"encodedscandata\", \"Material_Localised\":\"Divergent Scan Data\", \"Quantity\":1 } }" },
            };
    }
}