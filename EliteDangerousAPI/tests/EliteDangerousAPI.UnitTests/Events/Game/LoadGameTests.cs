using System;
using System.Collections.Generic;
using NSW.EliteDangerous.API;
using NSW.EliteDangerous.API.Events;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class LoadGameTests
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = (API.EliteDangerousAPI)TestHelpers.TestApi;
            var eventFired = false;
            api.Game.LoadGame += (sender, @event) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as LoadGameEvent);
            Assert.True(eventFired);
        }

        private void AssertEvent(LoadGameEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2017-02-10T14:25:51Z"), @event.Timestamp);
            Assert.Equal("LoadGame", @event.Event);
            Assert.Equal("HRC-2", @event.Commander);
            Assert.Equal("F44396", @event.FrontierId);
            Assert.True(@event.Horizons);
            Assert.Equal("FerDeLance", @event.Ship);
            Assert.Equal(19, @event.ShipId);
            Assert.Equal("jewel of parhoon", @event.ShipName);
            Assert.Equal("hr-17f", @event.ShipIdent);
            Assert.Equal(3.964024, @event.FuelLevel, 6);
            Assert.Equal(8.000000, @event.FuelCapacity, 6);
            Assert.Equal(GameMode.Open, @event.GameMode);
            Assert.Equal(2890718739, @event.Credits);
            Assert.Equal(0, @event.Loan);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { "LoadGame",  "{ \"timestamp\":\"2017-02-10T14:25:51Z\", \"event\":\"LoadGame\", \"Commander\":\"HRC-2\",\r\n\"FID\":\"F44396\", \"Horizons\":true, \"Ship\":\"FerDeLance\", \"ShipID\":19, \"ShipName\":\"jewel of parhoon\",\r\n\"ShipIdent\":\"hr-17f\", \"FuelLevel\":3.964024, \"FuelCapacity\":8.000000, \"GameMode\":\"Open\",\r\n\"Credits\":2890718739, \"Loan\":0 } " },
            };
    }
}