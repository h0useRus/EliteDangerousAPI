using System;
using System.Collections.Generic;
using NSW.EliteDangerous.API.Events;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class MissionsEventTests
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = (API.EliteDangerousAPI)TestHelpers.TestApi;
            var eventFired = false;
            api.PlayerEvents.Missions += (sender, @event) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as MissionsEvent);
            Assert.True(eventFired);
        }

        private void AssertEvent(MissionsEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2017-10-02T10:37:58Z"), @event.Timestamp);
            Assert.Equal("Missions", @event.Event);

            Assert.Equal(65380900, @event.Active[0].MissionId);
            Assert.Equal("Mission_Courier_name", @event.Active[0].Name);
            Assert.Equal(82751, @event.Active[0].Expires);
            Assert.False(@event.Active[0].PassengerMission);
            
            Assert.Equal(65480700, @event.Complete[0].MissionId);
            Assert.Equal("Mission_Pass_name", @event.Complete[0].Name);
            Assert.Equal(0, @event.Complete[0].Expires);
            Assert.True(@event.Complete[0].PassengerMission);

            Assert.Empty(@event.Failed);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { "Missions", "{ \"timestamp\":\"2017-10-02T10:37:58Z\", \"event\":\"Missions\", \"Active\":[ { \"MissionID\":65380900,\r\n\"Name\":\"Mission_Courier_name\", \"PassengerMission\":false, \"Expires\":82751 } ], \"Failed\":[ ],\r\n\"Complete\":[ { \"MissionID\":65480700, \"Name\":\"Mission_Pass_name\", \"PassengerMission\":true } ] }" },
            };
    }
}