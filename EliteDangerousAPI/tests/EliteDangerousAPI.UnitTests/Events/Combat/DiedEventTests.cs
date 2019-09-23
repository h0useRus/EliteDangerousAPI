using System;
using System.Collections.Generic;
using NSW.EliteDangerous.API;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class DiedEventTests
    {
        private const string EventName = "Died";

        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = (API.EliteDangerousAPI)TestHelpers.TestApi;
            var eventFired = false;
            api.Combat.Died += (sender, @event) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as DiedEvent);
            Assert.True(eventFired);
        }

        private void AssertEvent(DiedEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2019-09-04T14:30:18Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal("$ShipName_Police_Federation;", @event.KillerName);
            Assert.Equal("Федеральная служба безопасности", @event.KillerNameLocalised);
            Assert.Equal("viper_mkiv", @event.KillerShip);
            Assert.Equal(CombatRank.Master, @event.KillerRank);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2019-09-04T14:30:18Z\", \"event\":\"Died\", \"KillerName\":\"$ShipName_Police_Federation;\", \"KillerName_Localised\":\"Федеральная служба безопасности\", \"KillerShip\":\"viper_mkiv\", \"KillerRank\":\"Master\" }\r\n" },
            };
    }
}