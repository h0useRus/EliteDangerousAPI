using System;
using System.Collections.Generic;
using NSW.EliteDangerous.API.Events;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class PowerplayVoucherEventTests
    {
        private const string EventName = "PowerplayVoucher";

        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = (API.EliteDangerousAPI)TestHelpers.TestApi;
            var globalFired = false;
            var eventFired = false;

            api.AllEvents += (s, e) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(s);
                Assert.Equal(EventName.ToLower(), e.EventName);
                Assert.Equal(typeof(PowerplayVoucherEvent), e.EventType);
                Assert.IsType<PowerplayVoucherEvent>(e.Event);
                AssertEvent((PowerplayVoucherEvent)e.Event);
                globalFired = true;
            };

            api.Powerplay.PowerplayVoucher += (sender, @event) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as PowerplayVoucherEvent);
            Assert.True(eventFired, $"Event {EventName} is not thrown");
            Assert.True(globalFired, "Global event is not thrown");
        }

        private void AssertEvent(PowerplayVoucherEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2016-06-10T14:32:03Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal("Li Yong-Rui", @event.Power);
            Assert.Equal("Njortamool", @event.Systems[0]);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2016-06-10T14:32:03Z\", \"event\":\"PowerplayVoucher\", \"Power\":\"Li Yong-Rui\", \"Systems\": [\"Njortamool\"] }" },
            };
    }
}