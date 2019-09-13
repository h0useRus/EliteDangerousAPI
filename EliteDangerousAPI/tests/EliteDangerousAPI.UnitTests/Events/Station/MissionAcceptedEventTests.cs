using System;
using System.Collections.Generic;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class MissionAcceptedEventTests
    {
        private const string EventName = "MissionAccepted";

        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = new EliteDangerousAPI();
            var eventFired = false;
            api.Station.MissionAccepted += (sender, @event) =>
            {
                Assert.IsType<EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as MissionAcceptedEvent);
            Assert.True(eventFired, $"Event {EventName} is not thrown");
        }

        private static void AssertEvent(MissionAcceptedEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2019-09-08T10:24:53Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal(508888377, @event.MissionId);
            Assert.Equal("Mission_Delivery", @event.Name);
            Assert.Equal("Доставьте 45 шт. товара  Сверхпроводники", @event.NameLocalised);
            Assert.Equal("Scylla Gold Boys", @event.Faction);
            Assert.Equal("$Superconductors_Name;", @event.Commodity);
            Assert.Equal("Сверхпроводники", @event.CommodityLocalised);
            Assert.Equal(45, @event.Count);
            Assert.Equal("Eurybia Blue Mafia", @event.TargetFaction);
            Assert.Equal("Scylla", @event.DestinationSystem);
            Assert.Equal("Qureshi Port", @event.DestinationStation);
            Assert.Equal(DateTime.Parse("2019-09-09T10:21:33Z"), @event.Expiry);
            Assert.False(@event.Wing);
            Assert.Equal("++", @event.Influence);
            Assert.Equal("++", @event.Reputation);
            Assert.Equal(869438, @event.Reward);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2019-09-08T10:24:53Z\", \"event\":\"MissionAccepted\", \"Faction\":\"Scylla Gold Boys\", \"Name\":\"Mission_Delivery\", \"LocalisedName\":\"Доставьте 45 шт. товара  Сверхпроводники\", \"Commodity\":\"$Superconductors_Name;\", \"Commodity_Localised\":\"Сверхпроводники\", \"Count\":45, \"TargetFaction\":\"Eurybia Blue Mafia\", \"DestinationSystem\":\"Scylla\", \"DestinationStation\":\"Qureshi Port\", \"Expiry\":\"2019-09-09T10:21:33Z\", \"Wing\":false, \"Influence\":\"++\", \"Reputation\":\"++\", \"Reward\":869438, \"MissionID\":508888377 }" },
            };
    }
}