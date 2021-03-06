using System;
using System.Collections.Generic;
using NSW.EliteDangerous.API;
using NSW.EliteDangerous.API.Events;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class FriendsEventTests
    {
        private const string EventName = "Friends";

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
                Assert.Equal(typeof(FriendsEvent), e.EventType);
                Assert.IsType<FriendsEvent>(e.Event);
                AssertEvent((FriendsEvent)e.Event);
                globalFired = true;
            };

            api.PlayerEvents.Friends += (sender, @event) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as FriendsEvent);
            Assert.True(eventFired, $"Event {EventName} is not thrown");
            Assert.True(globalFired, "Global event is not thrown");
        }

        private void AssertEvent(FriendsEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2019-08-30T13:03:45Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal(FriendStatus.Added, @event.Status);
            Assert.Equal("Viktor Gingerbeard", @event.Name);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2019-08-30T13:03:45Z\", \"event\":\"Friends\", \"Status\":\"Added\", \"Name\":\"Viktor Gingerbeard\" }" },
            };
    }
}