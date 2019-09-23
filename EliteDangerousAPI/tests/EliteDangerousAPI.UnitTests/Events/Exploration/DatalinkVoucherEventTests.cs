using System;
using System.Collections.Generic;
using NSW.EliteDangerous.API.Events;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class DatalinkVoucherEventTests
    {
        private const string EventName = "DatalinkVoucher";

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
                Assert.Equal(typeof(DatalinkVoucherEvent), e.EventType);
                Assert.IsType<DatalinkVoucherEvent>(e.Event);
                AssertEvent((DatalinkVoucherEvent)e.Event);
                globalFired = true;
            };

            api.Exploration.DatalinkVoucher += (sender, @event) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as DatalinkVoucherEvent);
            Assert.True(eventFired, $"Event {EventName} is not thrown");
            Assert.True(globalFired, "Global event is not thrown");
        }

        private void AssertEvent(DatalinkVoucherEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2019-09-11T13:04:24Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal(6811, @event.Reward);
            Assert.Equal(string.Empty, @event.VictimFaction);
            Assert.Equal("Alliance", @event.PayeeFaction);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2019-09-11T13:04:24Z\", \"event\":\"DatalinkVoucher\", \"Reward\":6811, \"VictimFaction\":\"\", \"PayeeFaction\":\"Alliance\" }" },
            };
    }
}