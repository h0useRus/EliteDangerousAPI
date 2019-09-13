using System;
using System.Collections.Generic;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class MissionRedirectedEventTests
    {
        private const string EventName = "MissionRedirected";

        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = new EliteDangerousAPI();
            var eventFired = false;
            api.Station.MissionRedirected += (sender, @event) =>
            {
                Assert.IsType<EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as MissionRedirectedEvent);
            Assert.True(eventFired, $"Event {EventName} is not thrown");
        }

        private static void AssertEvent(MissionRedirectedEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2017-08-01T09:04:07Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal(65367315, @event.MissionId);
            Assert.Null(@event.Name);
            Assert.Equal("Metcalf Orbital", @event.NewDestinationStation);
            Assert.Equal("Cuffey Orbital", @event.OldDestinationStation);
            Assert.Equal("Cemiess", @event.NewDestinationSystem);
            Assert.Equal("Vequess", @event.OldDestinationSystem);
            
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\": \"2017-08-01T09:04:07Z\", \"event\": \"MissionRedirected\", \"MissionID\": 65367315,\"NewDestinationStation\": \"Metcalf Orbital\", \"OldDestinationStation\": \"Cuffey Orbital\",\"NewDestinationSystem\": \"Cemiess\", \"OldDestinationSystem\": \"Vequess\" } " },
            };
    }
}