using System;
using System.Collections.Generic;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class CapShipBondEventTests
    {
        private const string EventName = "CapShipBond";

        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = new EliteDangerousAPI();
            var eventFired = false;
            api.Combat.CapShipBond += (sender, @event) =>
            {
                Assert.IsType<EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as CapShipBondEvent);
            Assert.True(eventFired);
        }

        private void AssertEvent(CapShipBondEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2019-09-03T13:38:51Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            // TODO: Add more tests
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2019-09-03T13:38:51Z\", \"event\":\"CapShipBond\" }" },
            };
    }
}