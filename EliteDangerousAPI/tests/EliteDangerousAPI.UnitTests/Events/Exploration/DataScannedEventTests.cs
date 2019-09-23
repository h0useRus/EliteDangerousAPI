using System;
using System.Collections.Generic;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class DataScannedEventTests
    {
        private const string EventName = "DataScanned";

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
                Assert.Equal(typeof(DataScannedEvent), e.EventType);
                Assert.IsType<DataScannedEvent>(e.Event);
                AssertEvent((DataScannedEvent)e.Event);
                globalFired = true;
            };

            api.Exploration.DataScanned += (sender, @event) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as DataScannedEvent);
            Assert.True(eventFired, $"Event {EventName} is not thrown");
            Assert.True(globalFired, "Global event is not thrown");
        }

        private void AssertEvent(DataScannedEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2019-09-11T12:57:40Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal("$Datascan_AbandonedDataLog;", @event.Type);
            Assert.Equal("Брошенный журнал данных", @event.TypeLocalised);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2019-09-11T12:57:40Z\", \"event\":\"DataScanned\", \"Type\":\"$Datascan_AbandonedDataLog;\", \"Type_Localised\":\"Брошенный журнал данных\" }" },
            };
    }
}