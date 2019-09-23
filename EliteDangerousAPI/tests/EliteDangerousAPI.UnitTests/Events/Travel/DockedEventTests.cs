using System;
using System.Collections.Generic;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class DockedEventTests
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = (API.EliteDangerousAPI)TestHelpers.TestApi;
            var eventFired = false;
            api.Travel.Docked += (sender, @event) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as DockedEvent);
            Assert.True(eventFired);
        }

        private void AssertEvent(DockedEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2019-09-08T09:53:44Z"), @event.Timestamp);
            Assert.Equal("Docked", @event.Event);
            Assert.Equal("Krikalev Hangar", @event.StationName);
            Assert.Equal("Outpost", @event.StationType);
            Assert.Equal("Njortamool", @event.StarSystem);
            Assert.Equal(5372466973488, @event.SystemAddress);
            Assert.Equal(3223662592, @event.MarketId);
            Assert.Equal("Eurybia Blue Mafia", @event.StationFaction.Name);
            Assert.Equal("Expansion", @event.StationFaction.State);
            Assert.Equal("$government_Anarchy;", @event.StationGovernment);
            Assert.Equal("Анархия", @event.StationGovernmentLocalised);
            Assert.Equal(17, @event.StationServices.Length);
            Assert.Equal("$economy_Refinery;", @event.StationEconomy);
            Assert.Equal("Переработка", @event.StationEconomyLocalised);
            Assert.Equal("$economy_Refinery;", @event.StationEconomies[0].Name);
            Assert.Equal("Переработка", @event.StationEconomies[0].NameLocalised);
            Assert.Equal(1.000000, @event.StationEconomies[0].Proportion, 6);
            Assert.Equal(4479.807617, @event.DistFromStarLs, 6);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { "Docked",  "{ \"timestamp\":\"2019-09-08T09:53:44Z\", \"event\":\"Docked\", \"StationName\":\"Krikalev Hangar\", \"StationType\":\"Outpost\", \"StarSystem\":\"Njortamool\", \"SystemAddress\":5372466973488, \"MarketID\":3223662592, \"StationFaction\":{ \"Name\":\"Eurybia Blue Mafia\", \"FactionState\":\"Expansion\" }, \"StationGovernment\":\"$government_Anarchy;\", \"StationGovernment_Localised\":\"Анархия\", \"StationServices\":[ \"Dock\", \"Autodock\", \"BlackMarket\", \"Commodities\", \"Contacts\", \"Exploration\", \"Missions\", \"Refuel\", \"Repair\", \"Tuning\", \"Workshop\", \"MissionsGenerated\", \"Facilitator\", \"FlightController\", \"StationOperations\", \"Powerplay\", \"StationMenu\" ], \"StationEconomy\":\"$economy_Refinery;\", \"StationEconomy_Localised\":\"Переработка\", \"StationEconomies\":[ { \"Name\":\"$economy_Refinery;\", \"Name_Localised\":\"Переработка\", \"Proportion\":1.000000 } ], \"DistFromStarLS\":4479.807617 }\r\n" },
            };
    }
}