using System;
using System.Collections.Generic;
using NSW.EliteDangerous.API.Events;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class ModuleSellEventTests
    {
        private const string EventName = "ModuleSell";

        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = (API.EliteDangerousAPI)TestHelpers.TestApi;
            var eventFired = false;
            api.StationEvents.ModuleSell += (sender, @event) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as ModuleSellEvent);
            Assert.True(eventFired, $"Event {EventName} is not thrown");
        }

        private static void AssertEvent(ModuleSellEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2019-09-08T10:24:02Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal("Slot07_Size1", @event.Slot);
            Assert.Equal(2, @event.ShipId);
            Assert.Equal("cobramkiii", @event.Ship);
            Assert.Equal(3223641856, @event.MarketId);
            Assert.Equal("$int_dronecontrol_collection_size1_class5_name;", @event.SellItem);
            Assert.Equal("«Сборщик»", @event.SellItemLocalised);
            Assert.Equal(8160, @event.SellPrice);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2019-09-08T10:24:02Z\", \"event\":\"ModuleSell\", \"MarketID\":3223641856, \"Slot\":\"Slot07_Size1\", \"SellItem\":\"$int_dronecontrol_collection_size1_class5_name;\", \"SellItem_Localised\":\"«Сборщик»\", \"SellPrice\":8160, \"Ship\":\"cobramkiii\", \"ShipID\":2 }" },
            };
    }
}