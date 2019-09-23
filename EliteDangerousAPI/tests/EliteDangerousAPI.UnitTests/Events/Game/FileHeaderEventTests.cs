using System;
using System.Collections.Generic;
using NSW.EliteDangerous.API.Events;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class FileHeaderEventTests
    {
        private const string EventName = "Fileheader";

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
                Assert.Equal(typeof(FileHeaderEvent), e.EventType);
                Assert.IsType<FileHeaderEvent>(e.Event);
                AssertEvent((FileHeaderEvent)e.Event);
                globalFired = true;
            };

            api.Game.FileHeader += (sender, @event) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as FileHeaderEvent);
            Assert.True(eventFired, $"Event {EventName} is not thrown");
            Assert.True(globalFired, "Global event is not thrown");
        }

        private void AssertEvent(FileHeaderEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2019-08-29T23:23:18Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal(1, @event.Part);
            Assert.Equal("Russian\\RU", @event.Language);
            Assert.Equal("April Update Patch 2 EDH", @event.GameVersion);
            Assert.Equal("r200296/r0 ", @event.Build);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2019-08-29T23:23:18Z\", \"event\":\"Fileheader\", \"part\":1, \"language\":\"Russian\\\\RU\", \"gameversion\":\"April Update Patch 2 EDH\", \"build\":\"r200296/r0 \" }" },
            };
    }
}