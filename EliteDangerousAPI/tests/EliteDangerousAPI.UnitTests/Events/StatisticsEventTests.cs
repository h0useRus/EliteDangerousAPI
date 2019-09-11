using System;
using System.Collections.Generic;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class StatisticsEventTests
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = new EliteDangerousAPI();
            var eventFired = false;
            api.Player.Statistics += (sender, @event) =>
            {
                Assert.IsType<EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as StatisticsEvent);
            Assert.True(eventFired);
        }

        private void AssertEvent(StatisticsEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2017-09-25T15:18:31Z"), @event.Timestamp);
            Assert.Equal("Statistics", @event.Event);

            Assert.Equal(148827050, @event.BankAccount.CurrentWealth);
            Assert.Equal(14499177, @event.BankAccount.SpentOnShips);
            Assert.Equal(30785093, @event.BankAccount.SpentOnOutfitting);
            Assert.Equal(17716, @event.BankAccount.SpentOnRepairs);
            Assert.Equal(1647, @event.BankAccount.SpentOnFuel);
            Assert.Equal(0, @event.BankAccount.SpentOnAmmoConsumables);
            Assert.Equal(4, @event.BankAccount.InsuranceClaims);
            Assert.Equal(1397620, @event.BankAccount.SpentOnInsurance);

            Assert.Equal(0, @event.Combat.BountiesClaimed);
            Assert.Equal(0, @event.Combat.BountyHuntingProfit);
            Assert.Equal(0, @event.Combat.CombatBonds);
            Assert.Equal(0, @event.Combat.CombatBondProfits);
            Assert.Equal(0, @event.Combat.Assassinations);
            Assert.Equal(0, @event.Combat.AssassinationProfits);
            Assert.Equal(0, @event.Combat.HighestSingleReward);
            Assert.Equal(0, @event.Combat.SkimmersKilled);

            Assert.Equal(0, @event.Crime.Fines);
            Assert.Equal(0, @event.Crime.TotalFines);
            Assert.Equal(0, @event.Crime.BountiesReceived);
            Assert.Equal(0, @event.Crime.TotalBounties);
            Assert.Equal(0, @event.Crime.HighestBounty);

            Assert.Equal(0, @event.Smuggling.BlackMarketsTradedWith);
            Assert.Equal(0, @event.Smuggling.BlackMarketsProfits);
            Assert.Equal(0, @event.Smuggling.ResourcesSmuggled);
            Assert.Equal(0, @event.Smuggling.AverageProfit);
            Assert.Equal(0, @event.Smuggling.HighestSingleTransaction);

            Assert.Equal(3, @event.Trading.MarketsTradedWith);
            Assert.Equal(40700, @event.Trading.MarketProfits);
            Assert.Equal(23, @event.Trading.ResourcesTraded);
            Assert.Equal(4070, @event.Trading.AverageProfit);
            Assert.Equal(17961, @event.Trading.HighestSingleTransaction);

            Assert.Equal(0, @event.Mining.MiningProfits);
            Assert.Equal(0, @event.Mining.QuantityMined);
            Assert.Equal(100, @event.Mining.MaterialsCollected);

            Assert.Equal(228, @event.Exploration.SystemsVisited);
            Assert.Equal(111, @event.Exploration.FuelScooped);
            Assert.Equal(0, @event.Exploration.FuelPurchased);
            Assert.Equal(304469, @event.Exploration.ExplorationProfits);
            Assert.Equal(39, @event.Exploration.PlanetsScannedToLevel2);
            Assert.Equal(15, @event.Exploration.PlanetsScannedToLevel3);
            Assert.Equal(52503, @event.Exploration.HighestPayout);
            Assert.Equal(844927, @event.Exploration.TotalHyperspaceDistance);
            Assert.Equal(295, @event.Exploration.TotalHyperspaceJumps);
            Assert.Equal(65222.47204614, @event.Exploration.GreatestDistanceFromStart, 8);
            Assert.Equal(651060, @event.Exploration.TimePlayed);

            Assert.Equal(0, @event.Passengers.MissionsBulk);
            Assert.Equal(0, @event.Passengers.MissionsVip);
            Assert.Equal(0, @event.Passengers.MissionsDelivered);
            Assert.Equal(0, @event.Passengers.MissionsEjected);

            Assert.Equal(12, @event.SearchAndRescue.Traded);
            Assert.Equal(19467, @event.SearchAndRescue.Profit);
            Assert.Equal(8, @event.SearchAndRescue.Count);

            Assert.Equal(0, @event.Crafting.SpentOnCrafting);
            Assert.Equal(2, @event.Crafting.CountOfUsedEngineers);
            Assert.Equal(28, @event.Crafting.RecipesGenerated);
            Assert.Equal(9, @event.Crafting.RecipesGeneratedRank1);
            Assert.Equal(6, @event.Crafting.RecipesGeneratedRank2);
            Assert.Equal(9, @event.Crafting.RecipesGeneratedRank3);
            Assert.Equal(4, @event.Crafting.RecipesGeneratedRank4);
            Assert.Equal(0, @event.Crafting.RecipesGeneratedRank5);
            Assert.Equal(21, @event.Crafting.RecipesApplied);
            Assert.Equal(8, @event.Crafting.RecipesAppliedRank1);
            Assert.Equal(5, @event.Crafting.RecipesAppliedRank2);
            Assert.Equal(7, @event.Crafting.RecipesAppliedRank3);
            Assert.Equal(1, @event.Crafting.RecipesAppliedRank4);
            Assert.Equal(0, @event.Crafting.RecipesAppliedRank5);
            Assert.Equal(0, @event.Crafting.RecipesAppliedOnPreviouslyModifiedModules);

            Assert.Equal(0, @event.NpcCrew.TotalWages);
            Assert.Equal(0, @event.NpcCrew.Hired);
            Assert.Equal(0, @event.NpcCrew.Fired);
            Assert.Equal(0, @event.NpcCrew.Died);

            Assert.Equal(23327, @event.MultiCrew.TimeTotal);
            Assert.Equal(14241, @event.MultiCrew.GunnerTimeTotal);
            Assert.Equal(6070, @event.MultiCrew.FighterTimeTotal);
            Assert.Equal(0, @event.MultiCrew.CreditsTotal);
            Assert.Equal(0, @event.MultiCrew.FinesTotal);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { "Statistics",  "{ \"timestamp\":\"2017-09-25T15:18:31Z\", \"event\":\"Statistics\", \"Bank_Account\":{ \"Current_Wealth\":148827050,\r\n\"Spent_On_Ships\":14499177, \"Spent_On_Outfitting\":30785093, \"Spent_On_Repairs\":17716, \"Spent_On_Fuel\":1647,\r\n\"Spent_On_Ammo_Consumables\":0, \"Insurance_Claims\":4, \"Spent_On_Insurance\":1397620 }, \"Combat\":{\r\n\"Bounties_Claimed\":0, \"Bounty_Hunting_Profit\":0, \"Combat_Bonds\":0, \"Combat_Bond_Profits\":0, \"Assassinations\":0,\r\n\"Assassination_Profits\":0, \"Highest_Single_Reward\":0, \"Skimmers_Killed\":0 }, \"Crime\":{ \"Fines\":0, \"Total_Fines\":0,\r\n\"Bounties_Received\":0, \"Total_Bounties\":0, \"Highest_Bounty\":0 }, \"Smuggling\":{ \"Black_Markets_Traded_With\":0,\r\n\"Black_Markets_Profits\":0, \"Resources_Smuggled\":0, \"Average_Profit\":0, \"Highest_Single_Transaction\":0 }, \"Trading\":{\r\n\"Markets_Traded_With\":3, \"Market_Profits\":40700, \"Resources_Traded\":23, \"Average_Profit\":4070,\r\n\"Highest_Single_Transaction\":17961 }, \"Mining\":{ \"Mining_Profits\":0, \"Quantity_Mined\":0, \"Materials_Collected\":100 },\r\n\"Exploration\":{ \"Systems_Visited\":228, \"Fuel_Scooped\":111, \"Fuel_Purchased\":0, \"Exploration_Profits\":304469,\r\n\"Planets_Scanned_To_Level_2\":39, \"Planets_Scanned_To_Level_3\":15, \"Highest_Payout\":52503,\r\n\"Total_Hyperspace_Distance\":844927, \"Total_Hyperspace_Jumps\":295, \"Greatest_Distance_From_Start\":65222.47204614,\r\n\"Time_Played\":651060 }, \"Passengers\":{ \"Passengers_Missions_Bulk\":0, \"Passengers_Missions_VIP\":0,\r\n\"Passengers_Missions_Delivered\":0, \"Passengers_Missions_Ejected\":0 }, \"Search_And_Rescue\":{\r\n\"SearchRescue_Traded\":12, \"SearchRescue_Profit\":19467, \"SearchRescue_Count\":8 }, \"Crafting\":{ \"Spent_On_Crafting\":0,\r\n\"Count_Of_Used_Engineers\":2, \"Recipes_Generated\":28, \"Recipes_Generated_Rank_1\":9,\r\n\"Recipes_Generated_Rank_2\":6, \"Recipes_Generated_Rank_3\":9, \"Recipes_Generated_Rank_4\":4,\r\n\"Recipes_Generated_Rank_5\":0, \"Recipes_Applied\":21, \"Recipes_Applied_Rank_1\":8, \"Recipes_Applied_Rank_2\":5,\r\n\"Recipes_Applied_Rank_3\":7, \"Recipes_Applied_Rank_4\":1, \"Recipes_Applied_Rank_5\":0,\r\n\"Recipes_Applied_On_Previously_Modified_Modules\":0 }, \"Crew\":{ \"NpcCrew_TotalWages\":0, \"NpcCrew_Hired\":0,\r\n\"NpcCrew_Fired\":0, \"NpcCrew_Died\":0 }, \"Multicrew\":{ \"Multicrew_Time_Total\":23327,\r\n\"Multicrew_Gunner_Time_Total\":14241, \"Multicrew_Fighter_Time_Total\":6070, \"Multicrew_Credits_Total\":0,\r\n\"Multicrew_Fines_Total\":0 } } " },
            };
    }
}