using System;
using System.Collections.Generic;
using NSW.EliteDangerous.API;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class RedeemVoucherEventTests
    {
        private const string EventName = "RedeemVoucher";

        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = (API.EliteDangerousAPI)TestHelpers.TestApi;
            var eventFired = false;

            api.AllEvents += (s, e) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(s);
                Assert.Equal(EventName.ToLower(), e.EventName);
                Assert.Equal(typeof(RedeemVoucherEvent), e.EventType);
                Assert.IsType<RedeemVoucherEvent>(e.Event);
            };

            api.Station.RedeemVoucher += (sender, @event) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as RedeemVoucherEvent);
            Assert.True(eventFired, $"Event {EventName} is not thrown");
        }

        private static void AssertEvent(RedeemVoucherEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2016-06-10T14:32:03Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal(VoucherType.Bounty, @event.Type);
            Assert.Equal("Ed's 38", @event.Factions[0].Faction);
            Assert.Equal(1000, @event.Factions[0].Amount);
            Assert.Equal("Zac's Lads", @event.Factions[1].Faction);
            Assert.Equal(2000, @event.Factions[1].Amount);
            Assert.Equal(0, @event.Amount);
            Assert.Equal(0, @event.BrokerPercentage);
            Assert.Null(@event.Faction);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2016-06-10T14:32:03Z\", \"event\":\"RedeemVoucher\", \"Type\":\"bounty\", Factions: [ { \"Faction\":\"Ed's 38\", \"Amount\":1000 }, { \"Faction\":\"Zac's Lads\", \"Amount\": 2000 } ] }" },
            };
    }
}