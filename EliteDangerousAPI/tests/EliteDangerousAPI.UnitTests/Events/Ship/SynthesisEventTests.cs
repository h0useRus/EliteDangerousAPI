using System;
using System.Collections.Generic;
using NSW.EliteDangerous.API.Events;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class SynthesisEventTests
    {
        private const string EventName = "Synthesis";

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
                Assert.Equal(typeof(SynthesisEvent), e.EventType);
                Assert.IsType<SynthesisEvent>(e.Event);
                AssertEvent((SynthesisEvent)e.Event);
                globalFired = true;
            };

            api.ShipEvents.Synthesis += (sender, @event) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as SynthesisEvent);
            Assert.True(eventFired, $"Event {EventName} is not thrown");
            Assert.True(globalFired, "Global event is not thrown");
        }

        private void AssertEvent(SynthesisEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2016-06-10T14:32:03Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal("Repair Basic", @event.Name);
            Assert.Equal(2, @event.Materials.Length);
            Assert.Equal("iron", @event.Materials[0].Name);
            Assert.Equal(2, @event.Materials[0].Count);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2016-06-10T14:32:03Z\", \"event\":\"Synthesis\", \"Name\":\"Repair Basic\", \"Materials\":[ {\"Name\":\"iron\", \"Count\":2}, {\"Name\":\"nickel\", \"Count\":1 } ] }" },
            };
    }
}