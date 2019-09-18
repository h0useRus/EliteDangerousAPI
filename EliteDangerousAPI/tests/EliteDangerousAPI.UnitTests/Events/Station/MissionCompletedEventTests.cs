using System;
using System.Collections.Generic;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class MissionCompletedEventTests
    {
        private const string EventName = "MissionCompleted";

        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = (EliteDangerousAPI)TestHelpers.TestApi;
            var eventFired = false;
            api.Station.MissionCompleted += (sender, @event) =>
            {
                Assert.IsType<EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as MissionCompletedEvent);
            Assert.True(eventFired, $"Event {EventName} is not thrown");
        }

        private static void AssertEvent(MissionCompletedEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2019-09-08T10:16:33Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal(508882881, @event.MissionId);
            Assert.Equal("Mission_Courier_Expansion_name", @event.Name);
            Assert.Equal("Eurybia Blue Mafia", @event.Faction);
            Assert.Null(@event.Commodity);
            Assert.Null(@event.CommodityLocalised);
            Assert.Null(@event.Count);
            Assert.Equal("Traditional Scylla League", @event.TargetFaction);
            Assert.Equal("Scylla", @event.DestinationSystem);
            Assert.Equal("Ham Dock", @event.DestinationStation);
            Assert.Equal(854162, @event.Reward);

            Assert.Equal(2, @event.FactionEffects.Length);
            Assert.Equal("Eurybia Blue Mafia", @event.FactionEffects[0].Faction);
            Assert.Equal("$MISSIONUTIL_Interaction_Summary_EP_up;", @event.FactionEffects[0].Effects[0].Effect);
            Assert.Equal("Экономическое состояние фракции $#MinorFaction; в системе $#System; улучшилось.", @event.FactionEffects[0].Effects[0].EffectLocalised);
            Assert.Equal("UpGood", @event.FactionEffects[0].Effects[0].Trend);
            Assert.Equal(5372466973488, @event.FactionEffects[0].Influence[0].SystemAddress);
            Assert.Equal("+", @event.FactionEffects[0].Influence[0].InfluenceValue);
            Assert.Equal("UpGood", @event.FactionEffects[0].Effects[0].Trend);
            Assert.Equal("+", @event.FactionEffects[0].Reputation);
            Assert.Equal("UpGood", @event.FactionEffects[0].ReputationTrend);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2019-09-08T10:16:33Z\", \"event\":\"MissionCompleted\", \"Faction\":\"Eurybia Blue Mafia\", \"Name\":\"Mission_Courier_Expansion_name\", \"MissionID\":508882881, \"TargetFaction\":\"Traditional Scylla League\", \"DestinationSystem\":\"Scylla\", \"DestinationStation\":\"Ham Dock\", \"Reward\":854162, \"FactionEffects\":[ { \"Faction\":\"Eurybia Blue Mafia\", \"Effects\":[ { \"Effect\":\"$MISSIONUTIL_Interaction_Summary_EP_up;\", \"Effect_Localised\":\"Экономическое состояние фракции $#MinorFaction; в системе $#System; улучшилось.\", \"Trend\":\"UpGood\" } ], \"Influence\":[ { \"SystemAddress\":5372466973488, \"Trend\":\"UpGood\", \"Influence\":\"+\" } ], \"ReputationTrend\":\"UpGood\", \"Reputation\":\"+\" }, { \"Faction\":\"Traditional Scylla League\", \"Effects\":[ { \"Effect\":\"$MISSIONUTIL_Interaction_Summary_EP_up;\", \"Effect_Localised\":\"Экономическое состояние фракции $#MinorFaction; в системе $#System; улучшилось.\", \"Trend\":\"UpGood\" } ], \"Influence\":[ { \"SystemAddress\":2008064955082, \"Trend\":\"UpGood\", \"Influence\":\"+\" } ], \"ReputationTrend\":\"UpGood\", \"Reputation\":\"+\" } ] }" },
            };
    }
}