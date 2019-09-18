using System;
using System.Collections.Generic;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class DatalinkScanEventTests
    {
        private const string EventName = "DatalinkScan";

        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = (EliteDangerousAPI)TestHelpers.TestApi;
            var globalFired = false;
            var eventFired = false;

            api.AllEvents += (s, e) =>
            {
                Assert.IsType<EliteDangerousAPI>(s);
                Assert.Equal(EventName.ToLower(), e.EventName);
                Assert.Equal(typeof(DatalinkScanEvent), e.EventType);
                Assert.IsType<DatalinkScanEvent>(e.Event);
                AssertEvent((DatalinkScanEvent)e.Event);
                globalFired = true;
            };

            api.Exploration.DatalinkScan += (sender, @event) =>
            {
                Assert.IsType<EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as DatalinkScanEvent);
            Assert.True(eventFired, $"Event {EventName} is not thrown");
            Assert.True(globalFired, "Global event is not thrown");
        }

        private void AssertEvent(DatalinkScanEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2019-09-11T13:04:24Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal("$DATAPOINT_GAMEPLAY_complete;", @event.Message);
            Assert.Equal("Внимание: все каналы телеметрии датчика установлены, сформирован пакет разведданных.", @event.MessageLocalised);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2019-09-11T13:04:24Z\", \"event\":\"DatalinkScan\", \"Message\":\"$DATAPOINT_GAMEPLAY_complete;\", \"Message_Localised\":\"Внимание: все каналы телеметрии датчика установлены, сформирован пакет разведданных.\" }" },
            };
    }
}