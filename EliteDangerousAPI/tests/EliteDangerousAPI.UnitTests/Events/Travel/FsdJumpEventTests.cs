using System;
using System.Collections.Generic;
using NSW.EliteDangerous.API;
using NSW.EliteDangerous.API.Events;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class FsdJumpEventTests
    {
        private const string EventName = "FSDJump";

        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = (API.EliteDangerousAPI)TestHelpers.TestApi;
            var eventFired = false;
            api.TravelEvents.FsdJump += (sender, @event) =>
            {
                Assert.IsType<API.EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as FsdJumpEvent);
            Assert.True(eventFired);
        }

        private void AssertEvent(FsdJumpEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2019-08-31T11:56:05Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal("Nanabozho", @event.StarSystem);
            Assert.Equal(2832698675930, @event.SystemAddress);
            Assert.Equal(22.93750, @event.StarPos[0], 5);
            Assert.Equal(-35.75000, @event.StarPos[1], 5);
            Assert.Equal(24.15625, @event.StarPos[2], 5);
            Assert.Equal("Independent", @event.SystemAllegiance);
            Assert.Equal("$economy_HighTech;", @event.SystemEconomy);
            Assert.Equal("Высокие технологии", @event.SystemEconomyLocalised);
            Assert.Equal("$economy_Refinery;", @event.SystemSecondEconomy);
            Assert.Equal("Переработка", @event.SystemSecondEconomyLocalised);
            Assert.Equal("$government_Dictatorship;", @event.SystemGovernment);
            Assert.Equal(GovernmentType.Dictatorship, @event.SystemGovernmentType);
            Assert.Equal("Диктатура", @event.SystemGovernmentLocalised);
            Assert.Equal("$SYSTEM_SECURITY_medium;", @event.SystemSecurity);
            Assert.Equal("Средн. ур. безопасности", @event.SystemSecurityLocalised);
            Assert.Equal(4488711, @event.Population);
            Assert.Equal("Nanabozho A", @event.Body);
            Assert.Equal(1, @event.BodyId);
            Assert.Equal(BodyType.Star, @event.BodyType);
            Assert.Equal(8.451, @event.JumpDist, 3);
            Assert.Equal(0.596440, @event.FuelUsed, 6);
            Assert.Equal(7.010800, @event.FuelLevel, 6);
            Assert.Equal("EG Union", @event.SystemFaction.Name);
            Assert.Equal("Expansion", @event.SystemFaction.State);

            Assert.Equal(8, @event.Factions.Length);
            Assert.Equal("Nanabozho Transport Holdings", @event.Factions[0].Name);
            Assert.Equal("CivilWar", @event.Factions[0].State);
            Assert.Equal("Corporate", @event.Factions[0].Government);
            Assert.Equal(GovernmentType.Corporate, @event.Factions[0].GovernmentType);
            Assert.Equal(0.105578, @event.Factions[0].Influence, 6);
            Assert.Equal("Federation", @event.Factions[0].Allegiance);
            Assert.Equal("$Faction_HappinessBand2;", @event.Factions[0].Happiness);
            Assert.Equal("Счастье", @event.Factions[0].HappinessLocalised);
            Assert.Equal(0.000000, @event.Factions[0].MyReputation, 6);
            Assert.Single(@event.Factions[0].ActiveStates);
            Assert.Equal("CivilWar", @event.Factions[0].ActiveStates[0].State);

            Assert.Single(@event.Conflicts);
            Assert.Equal("civilwar", @event.Conflicts[0].WarType);
            Assert.Equal("active", @event.Conflicts[0].Status);
            Assert.Equal("Nanabozho Transport Holdings", @event.Conflicts[0].Faction1.Name);
            Assert.Equal("Patrick Depot", @event.Conflicts[0].Faction1.Stake);
            Assert.Equal(2, @event.Conflicts[0].Faction1.WonDays);
            Assert.Equal("Elite Orange Cross", @event.Conflicts[0].Faction2.Name);
            Assert.Equal(string.Empty, @event.Conflicts[0].Faction2.Stake);
            Assert.Equal(0, @event.Conflicts[0].Faction2.WonDays);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2019-08-31T11:56:05Z\", \"event\":\"FSDJump\", \"StarSystem\":\"Nanabozho\", \"SystemAddress\":2832698675930, \"StarPos\":[22.93750,-35.75000,24.15625], \"SystemAllegiance\":\"Independent\", \"SystemEconomy\":\"$economy_HighTech;\", \"SystemEconomy_Localised\":\"Высокие технологии\", \"SystemSecondEconomy\":\"$economy_Refinery;\", \"SystemSecondEconomy_Localised\":\"Переработка\", \"SystemGovernment\":\"$government_Dictatorship;\", \"SystemGovernment_Localised\":\"Диктатура\", \"SystemSecurity\":\"$SYSTEM_SECURITY_medium;\", \"SystemSecurity_Localised\":\"Средн. ур. безопасности\", \"Population\":4488711, \"Body\":\"Nanabozho A\", \"BodyID\":1, \"BodyType\":\"Star\", \"JumpDist\":8.451, \"FuelUsed\":0.596440, \"FuelLevel\":7.010800, \"Factions\":[ { \"Name\":\"Nanabozho Transport Holdings\", \"FactionState\":\"CivilWar\", \"Government\":\"Corporate\", \"Influence\":0.105578, \"Allegiance\":\"Federation\", \"Happiness\":\"$Faction_HappinessBand2;\", \"Happiness_Localised\":\"Счастье\", \"MyReputation\":0.000000, \"ActiveStates\":[ { \"State\":\"CivilWar\" } ] }, { \"Name\":\"Pilots' Federation Local Branch\", \"FactionState\":\"None\", \"Government\":\"Democracy\", \"Influence\":0.000000, \"Allegiance\":\"PilotsFederation\", \"Happiness\":\"\", \"MyReputation\":-14.988100 }, { \"Name\":\"Freedom Party of Nanabozho\", \"FactionState\":\"None\", \"Government\":\"Dictatorship\", \"Influence\":0.108566, \"Allegiance\":\"Independent\", \"Happiness\":\"$Faction_HappinessBand2;\", \"Happiness_Localised\":\"Счастье\", \"MyReputation\":0.000000 }, { \"Name\":\"Crew of Nanabozho\", \"FactionState\":\"None\", \"Government\":\"Anarchy\", \"Influence\":0.009960, \"Allegiance\":\"Independent\", \"Happiness\":\"$Faction_HappinessBand2;\", \"Happiness_Localised\":\"Счастье\", \"MyReputation\":0.000000 }, { \"Name\":\"Progressive Party of Nanabozho\", \"FactionState\":\"None\", \"Government\":\"Democracy\", \"Influence\":0.126494, \"Allegiance\":\"Federation\", \"Happiness\":\"$Faction_HappinessBand2;\", \"Happiness_Localised\":\"Счастье\", \"MyReputation\":0.000000 }, { \"Name\":\"Nanabozho Crimson Transport Ind\", \"FactionState\":\"None\", \"Government\":\"Corporate\", \"Influence\":0.066733, \"Allegiance\":\"Independent\", \"Happiness\":\"$Faction_HappinessBand2;\", \"Happiness_Localised\":\"Счастье\", \"MyReputation\":0.000000 }, { \"Name\":\"EG Union\", \"FactionState\":\"Expansion\", \"Government\":\"Dictatorship\", \"Influence\":0.477092, \"Allegiance\":\"Independent\", \"Happiness\":\"$Faction_HappinessBand2;\", \"Happiness_Localised\":\"Счастье\", \"MyReputation\":0.000000, \"ActiveStates\":[ { \"State\":\"Boom\" }, { \"State\":\"Expansion\" } ] }, { \"Name\":\"Elite Orange Cross\", \"FactionState\":\"CivilWar\", \"Government\":\"Cooperative\", \"Influence\":0.105578, \"Allegiance\":\"Independent\", \"Happiness\":\"$Faction_HappinessBand2;\", \"Happiness_Localised\":\"Счастье\", \"MyReputation\":0.000000, \"ActiveStates\":[ { \"State\":\"CivilWar\" } ] } ], \"SystemFaction\":{ \"Name\":\"EG Union\", \"FactionState\":\"Expansion\" }, \"Conflicts\":[ { \"WarType\":\"civilwar\", \"Status\":\"active\", \"Faction1\":{ \"Name\":\"Nanabozho Transport Holdings\", \"Stake\":\"Patrick Depot\", \"WonDays\":2 }, \"Faction2\":{ \"Name\":\"Elite Orange Cross\", \"Stake\":\"\", \"WonDays\":0 } } ] }\r\n" },
            };
    }
}