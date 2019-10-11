using System;
using System.Collections.Generic;
using NSW.EliteDangerous.API;
using NSW.EliteDangerous.API.Events;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class ModuleSellRemoteEventTests
    {
        private const string EventName = "ModuleSellRemote";

        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = (API.EliteDangerousAPI)TestHelpers.TestApi;
            var eventFired = false;
            api.StationEvents.ModuleSellRemote += (sender, @event) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as ModuleSellRemoteEvent);
            Assert.True(eventFired, $"Event {EventName} is not thrown");
        }

        private static void AssertEvent(ModuleSellRemoteEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2019-09-01T13:24:19Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal(112, @event.StorageSlot);
            Assert.Equal(2, @event.ShipId);
            Assert.Equal(ShipType.CobraMkIII, @event.ShipType);
            Assert.Equal("$int_buggybay_size2_class1_name;", @event.SellItem);
            Assert.Equal("Гараж планет. транспорта", @event.SellItemLocalised);
            Assert.Equal(18000, @event.SellPrice);
            Assert.Equal(128672288, @event.ServerId);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2019-09-01T13:24:19Z\", \"event\":\"ModuleSellRemote\", \"StorageSlot\":112, \"SellItem\":\"$int_buggybay_size2_class1_name;\", \"SellItem_Localised\":\"Гараж планет. транспорта\", \"ServerId\":128672288, \"SellPrice\":18000, \"Ship\":\"cobramkiii\", \"ShipID\":2 }" },
            };
    }
}