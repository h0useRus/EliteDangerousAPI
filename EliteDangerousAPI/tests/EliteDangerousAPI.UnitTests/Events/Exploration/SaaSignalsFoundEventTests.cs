using System;
using System.Collections.Generic;
using NSW.EliteDangerous.API.Events;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class SaaSignalsFoundEventTests
    {
        private const string EventName = "SAASignalsFound";

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
                Assert.Equal(typeof(SaaSignalsFoundEvent), e.EventType);
                Assert.IsType<SaaSignalsFoundEvent>(e.Event);
                AssertEvent((SaaSignalsFoundEvent)e.Event);
                globalFired = true;
            };

            api.Exploration.SaaSignalsFound += (sender, @event) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as SaaSignalsFoundEvent);
            Assert.True(eventFired, $"Event {EventName} is not thrown");
            Assert.True(globalFired, "Global event is not thrown");
        }

        private void AssertEvent(SaaSignalsFoundEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2019-04-17T13:38:18Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal("Hermitage 4 A Ring", @event.BodyName);
            Assert.Equal(11, @event.BodyId);
            Assert.Equal(5363877956440, @event.SystemAddress);
            Assert.Equal("LowTemperatureDiamond", @event.Signals[0].Type);
            Assert.Equal("Low Temperature Diamonds", @event.Signals[0].TypeLocalised);
            Assert.Equal(1, @event.Signals[0].Count);
            Assert.Equal("Alexandrite", @event.Signals[1].Type);
            Assert.Null(@event.Signals[1].TypeLocalised);
            Assert.Equal(2, @event.Signals[1].Count);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2019-04-17T13:38:18Z\", \"event\":\"SAASignalsFound\", \"BodyName\":\"Hermitage 4 A Ring\", \"SystemAddress\":5363877956440, \"BodyID\":11, \"Signals\":[ { \"Type\":\"LowTemperatureDiamond\", \"Type_Localised\":\"Low Temperature Diamonds\", \"Count\":1 }, { \"Type\":\"Alexandrite\", \"Count\":2 } ] }" },
            };
    }
}