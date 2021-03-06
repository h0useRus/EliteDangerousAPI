using System;
using System.Collections.Generic;
using NSW.EliteDangerous.API;
using NSW.EliteDangerous.API.Events;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class LocationEventTests
    {
        private const string EventName = "Location";

        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = (API.EliteDangerousAPI)TestHelpers.TestApi;
            var eventFired = false;
            var locationFired = false;
            api.TravelEvents.Location += (sender, @event) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            api.LocationChanged += (s, e) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(s);

                Assert.Equal("Njortamool", e.StarSystem.Name);
                Assert.Equal(GovernmentType.Anarchy, e.StarSystem.Government);
                Assert.Equal(SecurityType.Anarchy, e.StarSystem.Security);
                Assert.Equal(EconomyType.Refinery, e.StarSystem.Economy);
                Assert.Equal(EconomyType.None, e.StarSystem.SecondEconomy);
                Assert.Equal("Eurybia Blue Mafia", e.StarSystem.Faction.Name);
                Assert.Equal("Expansion", e.StarSystem.Faction.State);
                Assert.Equal(29911, e.StarSystem.Population);

                Assert.Equal("Krikalev Hangar", e.Body.Name);
                Assert.Equal(BodyType.Station, e.Body.Type);

                Assert.Equal("Krikalev Hangar", e.Station.Name);
                Assert.Equal(StationType.Outpost, e.Station.Type);
                Assert.Equal(EconomyType.Refinery, e.Station.Economy);
                Assert.Equal(GovernmentType.Anarchy, e.Station.Government);
                Assert.Equal(Allegiance.Independent, e.Station.Allegiance);
                Assert.Equal("Eurybia Blue Mafia", e.Station.Faction.Name);
                Assert.Equal("Expansion", e.Station.Faction.State);
                Assert.Equal(3223662592, e.Station.MarketId);

                locationFired = true;
            };
            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as LocationEvent);
            Assert.True(eventFired);
            Assert.True(locationFired);
        }

        private void AssertEvent(LocationEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2019-09-08T09:53:44Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal(4479.807617, @event.DistFromStarLs, 6);
            Assert.True(@event.Docked);
            Assert.Equal("Krikalev Hangar", @event.StationName);
            Assert.Equal("Outpost", @event.StationType);
            Assert.Equal(3223662592, @event.MarketId);
            Assert.Equal("Eurybia Blue Mafia", @event.StationFaction.Name);
            Assert.Equal("Expansion", @event.StationFaction.State);
            Assert.Equal("$government_Anarchy;", @event.StationGovernment);
            Assert.Equal("Анархия", @event.StationGovernmentLocalised);
            Assert.Equal(GovernmentType.Anarchy, @event.StationGovernmentType);
            Assert.Equal(17, @event.StationServices.Length);
            Assert.Equal("$economy_Refinery;", @event.StationEconomy);
            Assert.Equal(EconomyType.Refinery, @event.StationEconomyType);
            Assert.Equal("Переработка", @event.StationEconomyLocalised);
            Assert.Equal("$economy_Refinery;", @event.StationEconomies[0].Name);
            Assert.Equal(EconomyType.Refinery, @event.StationEconomies[0].Type);
            Assert.Equal("Переработка", @event.StationEconomies[0].NameLocalised);
            Assert.Equal(1.000000, @event.StationEconomies[0].Proportion, 6);
            Assert.Equal("Njortamool", @event.StarSystem);
            Assert.Equal(5372466973488, @event.SystemAddress);
            Assert.Equal(46.65625, @event.StarPos[0], 5);
            Assert.Equal(-43.34375, @event.StarPos[1], 5);
            Assert.Equal(-43.68750, @event.StarPos[2], 5);
            Assert.Equal(Allegiance.Independent, @event.SystemAllegiance);
            Assert.Equal("$economy_Refinery;", @event.SystemEconomy);
            Assert.Equal(EconomyType.Refinery, @event.SystemEconomyType);
            Assert.Equal("Переработка", @event.SystemEconomyLocalised);
            Assert.Equal("$economy_None;", @event.SystemSecondEconomy);
            Assert.Equal(EconomyType.None, @event.SystemSecondEconomyType);
            Assert.Equal("Нет", @event.SystemSecondEconomyLocalised);
            Assert.Equal("$government_Anarchy;", @event.SystemGovernment);
            Assert.Equal(GovernmentType.Anarchy, @event.SystemGovernmentType);
            Assert.Equal("Анархия", @event.SystemGovernmentLocalised);
            Assert.Equal("$GAlAXY_MAP_INFO_state_anarchy;", @event.SystemSecurity);
            Assert.Equal(SecurityType.Anarchy, @event.SystemSecurityType);
            Assert.Equal("Анархия", @event.SystemSecurityLocalised);
            Assert.Equal(29911, @event.Population);
            Assert.Equal("Krikalev Hangar", @event.Body);
            Assert.Equal(16, @event.BodyId);
            Assert.Equal(BodyType.Station, @event.BodyType);
            Assert.Equal("Eurybia Blue Mafia", @event.SystemFaction.Name);
            Assert.Equal("Expansion", @event.SystemFaction.State);

            Assert.Equal(6, @event.Factions.Length);
            Assert.Equal("Eurybia Blue Mafia", @event.Factions[4].Name);
            Assert.Equal("Expansion", @event.Factions[4].State);
            Assert.Equal("Anarchy", @event.Factions[4].Government);
            Assert.Equal(GovernmentType.Anarchy, @event.Factions[4].GovernmentType);
            Assert.Equal(0.747000, @event.Factions[4].Influence, 6);
            Assert.Equal(Allegiance.Independent, @event.Factions[4].Allegiance);
            Assert.Equal(Happiness.Happy, @event.Factions[4].Happiness);
            Assert.Equal("Счастье", @event.Factions[4].HappinessLocalised);
            Assert.Equal(92.326302, @event.Factions[4].MyReputation, 6);
            Assert.Equal(State.Outbreak, @event.Factions[4].RecoveringStates[0].State);
            Assert.Equal(0, @event.Factions[4].RecoveringStates[0].Trend);
            Assert.Equal(State.Boom, @event.Factions[4].ActiveStates[0].State);
            Assert.Null(@event.Factions[4].ActiveStates[0].Trend);
            Assert.Equal(State.Expansion, @event.Factions[4].ActiveStates[1].State);
            Assert.Null(@event.Factions[4].ActiveStates[1].Trend);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2019-09-08T09:53:44Z\", \"event\":\"Location\", \"DistFromStarLS\":4479.807617, \"Docked\":true, \"StationName\":\"Krikalev Hangar\", \"StationType\":\"Outpost\", \"MarketID\":3223662592, \"StationFaction\":{ \"Name\":\"Eurybia Blue Mafia\", \"FactionState\":\"Expansion\" }, \"StationGovernment\":\"$government_Anarchy;\", \"StationGovernment_Localised\":\"Анархия\", \"StationServices\":[ \"Dock\", \"Autodock\", \"BlackMarket\", \"Commodities\", \"Contacts\", \"Exploration\", \"Missions\", \"Refuel\", \"Repair\", \"Tuning\", \"Workshop\", \"MissionsGenerated\", \"Facilitator\", \"FlightController\", \"StationOperations\", \"Powerplay\", \"StationMenu\" ], \"StationEconomy\":\"$economy_Refinery;\", \"StationEconomy_Localised\":\"Переработка\", \"StationEconomies\":[ { \"Name\":\"$economy_Refinery;\", \"Name_Localised\":\"Переработка\", \"Proportion\":1.000000 } ], \"StarSystem\":\"Njortamool\", \"SystemAddress\":5372466973488, \"StarPos\":[46.65625,-43.34375,-43.68750], \"SystemAllegiance\":\"Independent\", \"SystemEconomy\":\"$economy_Refinery;\", \"SystemEconomy_Localised\":\"Переработка\", \"SystemSecondEconomy\":\"$economy_None;\", \"SystemSecondEconomy_Localised\":\"Нет\", \"SystemGovernment\":\"$government_Anarchy;\", \"SystemGovernment_Localised\":\"Анархия\", \"SystemSecurity\":\"$GAlAXY_MAP_INFO_state_anarchy;\", \"SystemSecurity_Localised\":\"Анархия\", \"Population\":29911, \"Body\":\"Krikalev Hangar\", \"BodyID\":16, \"BodyType\":\"Station\", \"Factions\":[ { \"Name\":\"Pilots' Federation Local Branch\", \"FactionState\":\"None\", \"Government\":\"Democracy\", \"Influence\":0.000000, \"Allegiance\":\"PilotsFederation\", \"Happiness\":\"\", \"MyReputation\":-14.988100 }, { \"Name\":\"Njortamool Industries\", \"FactionState\":\"None\", \"Government\":\"Corporate\", \"Influence\":0.091000, \"Allegiance\":\"Federation\", \"Happiness\":\"$Faction_HappinessBand2;\", \"Happiness_Localised\":\"Счастье\", \"MyReputation\":0.000000 }, { \"Name\":\"Cama Zotz Holdings\", \"FactionState\":\"Outbreak\", \"Government\":\"Corporate\", \"Influence\":0.072000, \"Allegiance\":\"Federation\", \"Happiness\":\"$Faction_HappinessBand2;\", \"Happiness_Localised\":\"Счастье\", \"MyReputation\":2.640000, \"ActiveStates\":[ { \"State\":\"Outbreak\" } ] }, { \"Name\":\"Njortamool Purple Posse\", \"FactionState\":\"None\", \"Government\":\"Anarchy\", \"Influence\":0.029000, \"Allegiance\":\"Independent\", \"Happiness\":\"$Faction_HappinessBand2;\", \"Happiness_Localised\":\"Счастье\", \"MyReputation\":0.000000 }, { \"Name\":\"Eurybia Blue Mafia\", \"FactionState\":\"Expansion\", \"Government\":\"Anarchy\", \"Influence\":0.747000, \"Allegiance\":\"Independent\", \"Happiness\":\"$Faction_HappinessBand2;\", \"Happiness_Localised\":\"Счастье\", \"MyReputation\":92.326302, \"RecoveringStates\":[ { \"State\":\"Outbreak\", \"Trend\":0 } ], \"ActiveStates\":[ { \"State\":\"Boom\" }, { \"State\":\"Expansion\" } ] }, { \"Name\":\"New Njortamool Confederation\", \"FactionState\":\"None\", \"Government\":\"Confederacy\", \"Influence\":0.061000, \"Allegiance\":\"Federation\", \"Happiness\":\"$Faction_HappinessBand2;\", \"Happiness_Localised\":\"Счастье\", \"MyReputation\":0.000000 } ], \"SystemFaction\":{ \"Name\":\"Eurybia Blue Mafia\", \"FactionState\":\"Expansion\" } }" },
            };
    }
}