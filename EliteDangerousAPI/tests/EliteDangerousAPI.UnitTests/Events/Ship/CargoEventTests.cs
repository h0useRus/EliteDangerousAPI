using System;
using System.Collections.Generic;
using NSW.EliteDangerous.API;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class CargoEventTests
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = (API.EliteDangerousAPI)TestHelpers.TestApi;
            var eventFired = false;
            api.Ship.Cargo += (sender, @event) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as CargoEvent);
            Assert.True(eventFired);
        }

        private void AssertEvent(CargoEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2018-06-26T08:21:17Z"), @event.Timestamp);
            Assert.Equal("Cargo", @event.Event);
            Assert.Equal(VehicleType.Ship, @event.Vessel);
            Assert.Equal(3, @event.Inventory.Length);

            Assert.Equal("gold", @event.Inventory[0].Name);
            Assert.Null(@event.Inventory[0].NameLocalised);
            Assert.Null(@event.Inventory[0].MissionId);
            Assert.Equal(2, @event.Inventory[0].Count);
            Assert.Equal(1, @event.Inventory[0].Stolen);

            Assert.Equal("gold", @event.Inventory[1].Name);
            Assert.Null(@event.Inventory[1].NameLocalised);
            Assert.Equal(65397935, @event.Inventory[1].MissionId);
            Assert.Equal(14, @event.Inventory[1].Count);
            Assert.Equal(0, @event.Inventory[1].Stolen);

            Assert.Equal("iondistributor", @event.Inventory[2].Name);
            Assert.Equal("Ion Distributor", @event.Inventory[2].NameLocalised);
            Assert.Null(@event.Inventory[2].MissionId);
            Assert.Equal(2, @event.Inventory[2].Count);
            Assert.Equal(0, @event.Inventory[2].Stolen);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { "Cargo",  "{ \"timestamp\":\"2018-06-26T08:21:17Z\", \"event\":\"Cargo\", \"Vessel\":\"Ship\", \"Inventory\":[\r\n{ \"Name\":\"gold\", \"Count\":2, \"Stolen\":1 },\r\n{ \"Name\":\"gold\", \"MissionID\":65397935, \"Count\":14, \"Stolen\":0 },\r\n{ \"Name\":\"iondistributor\", \"Name_Localised\":\"Ion Distributor\", \"Count\":2 }\r\n] }" },
            };
    }
}