using System;
using System.Collections.Generic;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class ModuleBuyEventTests
    {
        private const string EventName = "ModuleBuy";

        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = (EliteDangerousAPI)TestHelpers.TestApi;
            var eventFired = false;
            api.Station.ModuleBuy += (sender, @event) =>
            {
                Assert.IsType<EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as ModuleBuyEvent);
            Assert.True(eventFired, $"Event {EventName} is not thrown");
        }

        private static void AssertEvent(ModuleBuyEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2019-09-08T10:24:17Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal("Slot07_Size1", @event.Slot);
            Assert.Equal("$int_cargorack_size1_class1_name;", @event.BuyItem);
            Assert.Equal("Груз. стеллаж", @event.BuyItemLocalised);
            Assert.Equal("Груз. стеллаж", @event.BuyItemLocalised);
            Assert.Equal(3223641856, @event.MarketId);
            Assert.Equal(1000, @event.BuyPrice);
            Assert.Equal(2, @event.ShipId);
            Assert.Equal("cobramkiii", @event.Ship);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2019-09-08T10:24:17Z\", \"event\":\"ModuleBuy\", \"Slot\":\"Slot07_Size1\", \"BuyItem\":\"$int_cargorack_size1_class1_name;\", \"BuyItem_Localised\":\"Груз. стеллаж\", \"MarketID\":3223641856, \"BuyPrice\":1000, \"Ship\":\"cobramkiii\", \"ShipID\":2 }" },
            };
    }
}