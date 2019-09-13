using System;
using System.Collections.Generic;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class StoredModulesEventTests
    {
        private const string EventName = "StoredModules";

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
                Assert.Equal(typeof(StoredModulesEvent), e.EventType);
                Assert.IsType<StoredModulesEvent>(e.Event);
                AssertEvent((StoredModulesEvent)e.Event);
                globalFired = true;
            };

            api.Station.StoredModules += (sender, @event) =>
            {
                Assert.IsType<EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as StoredModulesEvent);
            Assert.True(eventFired, $"Event {EventName} is not thrown");
            Assert.True(globalFired, "Global event is not thrown");
        }

        private static void AssertEvent(StoredModulesEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2018-01-31T10:55:16Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal("Farseer Inc", @event.StationName);
            Assert.Equal(128676487, @event.MarketId);
            Assert.Equal("Deciat", @event.StarSystem);
            Assert.Equal(2, @event.Items.Length);

            Assert.Equal("$int_engine_size3_class5_name;", @event.Items[0].Name);
            Assert.Equal("Thrusters", @event.Items[0].NameLocalised);
            Assert.Equal("Engine_Dirty", @event.Items[0].EngineerModifications);
            Assert.Equal(57, @event.Items[0].StorageSlot);
            Assert.Equal("Deciat", @event.Items[0].StarSystem);
            Assert.Equal(128676487, @event.Items[0].MarketId);
            Assert.Equal(0, @event.Items[0].TransferCost);
            Assert.Equal(0, @event.Items[0].TransferTime);
            Assert.Equal(495215, @event.Items[0].BuyPrice);
            Assert.Equal(1, @event.Items[0].Level);
            Assert.Equal(0.000000, @event.Items[0].Quality, 6);
            Assert.False(@event.Items[0].Hot);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2018-01-31T10:55:16Z\", \"event\":\"StoredModules\", \"MarketID\":128676487, \"StationName\":\"Farseer Inc\",\r\n\"StarSystem\":\"Deciat\", \"Items\":[\r\n { \"Name\":\"$int_engine_size3_class5_name;\", \"Name_Localised\":\"Thrusters\", \"StorageSlot\":57, \"StarSystem\":\"Deciat\",\r\n\"MarketID\":128676487, \"TransferCost\":0, \"TransferTime\":0, \"BuyPrice\":495215, \"Hot\":false,\r\n\"EngineerModifications\":\"Engine_Dirty\", \"Level\":1, \"Quality\":0.000000 },\r\n { \"Name\":\"$int_hyperdrive_size6_class5_name;\", \"Name_Localised\":\"FSD\", \"StorageSlot\":59, \"StarSystem\":\"Shinrarta Dezhra\", \"MarketID\":128666762, \"TransferCost\":79680, \"TransferTime\":1317, \"BuyPrice\":12620035, \"Hot\":false,\r\n\"EngineerModifications\":\"FSD_LongRange\", \"Level\":5, \"Quality\":0.000000 } ] } " }
            };
    }
}