using System;
using System.Collections.Generic;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class PayBountiesEventTests
    {
        private const string EventName = "PayBounties";

        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = (EliteDangerousAPI)TestHelpers.TestApi;
            var eventFired = false;

            api.AllEvents += (s, e) =>
            {
                Assert.IsType<EliteDangerousAPI>(s);
                Assert.Equal("paybounties", e.EventName);
                Assert.Equal(typeof(PayBountiesEvent), e.EventType);
                Assert.IsType<PayBountiesEvent>(e.Event);
            };

            api.Station.PayBounties += (sender, @event) =>
            {
                Assert.IsType<EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as PayBountiesEvent);
            Assert.True(eventFired, $"Event {EventName} is not thrown");
        }

        private static void AssertEvent(PayBountiesEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2019-08-30T13:49:02Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal(20919, @event.Amount);
            Assert.Equal("$faction_Independent;", @event.Faction);
            Assert.Equal("Независимые", @event.FactionLocalised);
            Assert.Equal(0, @event.ShipId);
            Assert.Equal(25.000000, @event.BrokerPercentage, 6);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2019-08-30T13:49:02Z\", \"event\":\"PayBounties\", \"Amount\":20919, \"Faction\":\"$faction_Independent;\", \"Faction_Localised\":\"Независимые\", \"ShipID\":0, \"BrokerPercentage\":25.000000 }\r\n" },
            };
    }
}