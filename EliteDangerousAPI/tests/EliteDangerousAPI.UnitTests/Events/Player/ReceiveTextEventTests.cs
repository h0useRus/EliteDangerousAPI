using System;
using System.Collections.Generic;
using NSW.EliteDangerous.Events.Entities;
using Xunit;

namespace NSW.EliteDangerous.Events.Player
{
    public class ReceiveTextEventTests
    {
        private const string EventName = "ReceiveText";

        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = new EliteDangerousAPI();
            var globalFired = false;
            var eventFired = false;

            api.AllEvents += (s, e) =>
            {
                Assert.IsType<EliteDangerousAPI>(s);
                Assert.Equal(EventName.ToLower(), e.EventName);
                Assert.Equal(typeof(ReceiveTextEvent), e.EventType);
                Assert.IsType<ReceiveTextEvent>(e.Event);
                AssertEvent((ReceiveTextEvent)e.Event);
                globalFired = true;
            };

            api.Player.ReceiveText += (sender, @event) =>
            {
                Assert.IsType<EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as ReceiveTextEvent);
            Assert.True(eventFired, $"Event {EventName} is not thrown");
            Assert.True(globalFired, "Global event is not thrown");
        }

        private void AssertEvent(ReceiveTextEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2019-08-29T11:36:51Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal("Mawson Dock", @event.From);
            Assert.Equal(MessageChannel.Npc, @event.Channel);
            Assert.Equal("$STATION_NoFireZone_exited;", @event.Message);
            Assert.Equal("Вы вышли из зоны запрета огня", @event.MessageLocalised);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2019-08-29T11:36:51Z\", \"event\":\"ReceiveText\", \"From\":\"Mawson Dock\", \"Message\":\"$STATION_NoFireZone_exited;\", \"Message_Localised\":\"Вы вышли из зоны запрета огня\", \"Channel\":\"npc\" }" },
            };
    }
}