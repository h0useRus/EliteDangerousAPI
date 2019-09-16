using System;
using System.Collections.Generic;
using System.Linq;
using NSW.EliteDangerous.Events.Entities;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class LoadoutEventTests
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = new EliteDangerousAPI();
            var eventFired = false;
            api.Ship.Loadout += (sender, @event) =>
            {
                Assert.IsType<EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as LoadoutEvent);
            Assert.True(eventFired);
        }

        private void AssertEvent(LoadoutEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2019-09-05T11:17:13Z"), @event.Timestamp);
            Assert.Equal("Loadout", @event.Event);
            Assert.Equal("cobramkiii", @event.Ship);
            Assert.Equal(2, @event.ShipId);
            Assert.Equal("SAINT ANNA", @event.ShipName);
            Assert.Equal("NSW-C3", @event.ShipIdent);
            Assert.Equal(157888, @event.HullValue);
            Assert.Equal(1961355, @event.ModulesValue);
            Assert.Equal(0.763044, @event.HullHealth, 6);
            Assert.Equal(279.600006, @event.UnladenMass, 6);
            Assert.Equal(44, @event.CargoCapacity);
            Assert.Equal(17.125910, @event.MaxJumpRange, 6);
            Assert.Equal(16.000000, @event.FuelCapacity.Main, 6);
            Assert.Equal(0.490000, @event.FuelCapacity.Reserve, 6);
            Assert.Equal(105964, @event.Rebuy);
            Assert.Equal(27, @event.Modules.Length);

            var module = @event.Modules[0];
            Assert.Equal("ShipCockpit", module.Slot);
            Assert.Equal("cobramkiii_cockpit", module.Item);
            Assert.Equal(1, module.Priority);
            Assert.Equal(0.993686, module.Health, 6);
            Assert.True(module.On);

            module = @event.Modules.First(m => m.Slot == "MediumHardpoint1");
            Assert.Equal("MediumHardpoint1", module.Slot);
            Assert.Equal("hpt_multicannon_gimbal_medium", module.Item);
            Assert.Equal(2, module.Priority);
            Assert.Equal(90, module.AmmoInClip);
            Assert.Equal(2100, module.AmmoInHopper);
            Assert.Equal(0.991438, module.Health, 6);
            Assert.True(module.On);

            module = @event.Modules.First(m => m.Slot == "Armour");
            Assert.Equal("Armour", module.Slot);
            Assert.Equal("cobramkiii_armour_grade3", module.Item);
            Assert.Equal(1, module.Priority);
            Assert.Equal(1.000000, module.Health, 6);
            Assert.Equal(300080, module.Engineering.EngineerId);
            Assert.Equal("Liz Ryder", module.Engineering.Engineer);
            Assert.Equal(100, module.Engineering.BlueprintId);
            Assert.Equal("Experimental armor", module.Engineering.BlueprintName);
            Assert.Equal(1, module.Engineering.Level);
            Assert.Equal(79.600006, module.Engineering.Quality, 6);
            Assert.Equal("Charm", module.Engineering.ExperimentalEffect);
            Assert.Equal(ModuleAttribute.DefenceModifierHealthMultiplier, module.Engineering.Modifications[0].Label);
            Assert.Equal(12.000000, module.Engineering.Modifications[0].Value, 6);
            Assert.Equal(5.000000, module.Engineering.Modifications[0].OriginalValue, 6);
            Assert.True(module.Engineering.Modifications[0].LessIsGood);
            Assert.True(module.On);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { "Loadout",  "{ \"timestamp\":\"2019-09-05T11:17:13Z\", \"event\":\"Loadout\", \"Ship\":\"cobramkiii\", \"ShipID\":2, \"ShipName\":\"SAINT ANNA\", \"ShipIdent\":\"NSW-C3\", \"HullValue\":157888, \"ModulesValue\":1961355, \"HullHealth\":0.763044, \"UnladenMass\":279.600006, \"CargoCapacity\":44, \"MaxJumpRange\":17.125910, \"FuelCapacity\":{ \"Main\":16.000000, \"Reserve\":0.490000 }, \"Rebuy\":105964, \"Modules\":[ { \"Slot\":\"ShipCockpit\", \"Item\":\"cobramkiii_cockpit\", \"On\":true, \"Priority\":1, \"Health\":0.993686 }, { \"Slot\":\"CargoHatch\", \"Item\":\"modularcargobaydoor\", \"On\":true, \"Priority\":3, \"Health\":0.990061 }, { \"Slot\":\"MediumHardpoint1\", \"Item\":\"hpt_multicannon_gimbal_medium\", \"On\":true, \"Priority\":2, \"AmmoInClip\":90, \"AmmoInHopper\":2100, \"Health\":0.991438 }, { \"Slot\":\"MediumHardpoint2\", \"Item\":\"hpt_multicannon_gimbal_medium\", \"On\":true, \"Priority\":2, \"AmmoInClip\":90, \"AmmoInHopper\":2100, \"Health\":0.996777 }, { \"Slot\":\"SmallHardpoint1\", \"Item\":\"hpt_pulselaser_gimbal_small\", \"On\":true, \"Priority\":2, \"Health\":0.980544 }, { \"Slot\":\"SmallHardpoint2\", \"Item\":\"hpt_pulselaser_gimbal_small\", \"On\":true, \"Priority\":2, \"Health\":0.997921 }, { \"Slot\":\"TinyHardpoint1\", \"Item\":\"hpt_crimescanner_size0_class2\", \"On\":true, \"Priority\":2, \"Health\":0.998792 }, { \"Slot\":\"TinyHardpoint2\", \"Item\":\"hpt_heatsinklauncher_turret_tiny\", \"On\":true, \"Priority\":1, \"AmmoInClip\":1, \"AmmoInHopper\":1, \"Health\":0.996353 }, { \"Slot\":\"PaintJob\", \"Item\":\"paintjob_cobramkiii_25thanniversary_01\", \"On\":true, \"Priority\":1, \"Health\":1.000000 }, { \"Slot\":\"Armour\", \"Item\":\"cobramkiii_armour_grade3\", \"On\":true, \"Priority\":1, \"Health\":1.000000, \"Engineering\" : { \"EngineerID\": 300080, \"Engineer\": \"Liz Ryder\", \"BlueprintID\": 100, \"BlueprintName\": \"Experimental armor\", \"Level\": 1, \"Quality\": 79.600006, \"ExperimentalEffect\": \"Charm\", \"Modifications\": [ { \"Label\": \"DefenceModifierHealthMultiplier\", \"Value\": 12.000000, \"OriginalValue\": 5.000000, \"LessIsGood\" : true } ] } }, { \"Slot\":\"PowerPlant\", \"Item\":\"int_powerplant_size4_class3\", \"On\":true, \"Priority\":1, \"Health\":0.991345 }, { \"Slot\":\"MainEngines\", \"Item\":\"int_engine_size4_class4\", \"On\":true, \"Priority\":0, \"Health\":0.997466 }, { \"Slot\":\"FrameShiftDrive\", \"Item\":\"int_hyperdrive_size4_class4\", \"On\":true, \"Priority\":0, \"Health\":0.981684 }, { \"Slot\":\"LifeSupport\", \"Item\":\"int_lifesupport_size3_class2\", \"On\":true, \"Priority\":1, \"Health\":0.988148 }, { \"Slot\":\"PowerDistributor\", \"Item\":\"int_powerdistributor_size3_class5\", \"On\":true, \"Priority\":0, \"Health\":0.987744 }, { \"Slot\":\"Radar\", \"Item\":\"int_sensors_size3_class2\", \"On\":true, \"Priority\":1, \"Health\":0.980317 }, { \"Slot\":\"FuelTank\", \"Item\":\"int_fueltank_size4_class3\", \"On\":true, \"Priority\":1, \"Health\":1.000000 }, { \"Slot\":\"Slot01_Size4\", \"Item\":\"int_shieldgenerator_size4_class3_fast\", \"On\":true, \"Priority\":1, \"Health\":0.986427 }, { \"Slot\":\"Slot02_Size4\", \"Item\":\"int_cargorack_size4_class1\", \"On\":true, \"Priority\":1, \"Health\":1.000000 }, { \"Slot\":\"Slot03_Size4\", \"Item\":\"int_cargorack_size4_class1\", \"On\":true, \"Priority\":1, \"Health\":1.000000 }, { \"Slot\":\"Slot04_Size2\", \"Item\":\"int_cargorack_size2_class1\", \"On\":true, \"Priority\":1, \"Health\":1.000000 }, { \"Slot\":\"Slot05_Size2\", \"Item\":\"int_cargorack_size2_class1\", \"On\":true, \"Priority\":1, \"Health\":1.000000 }, { \"Slot\":\"Slot06_Size2\", \"Item\":\"int_cargorack_size2_class1\", \"On\":true, \"Priority\":1, \"Health\":1.000000 }, { \"Slot\":\"Slot07_Size1\", \"Item\":\"int_dronecontrol_collection_size1_class5\", \"On\":true, \"Priority\":2, \"Health\":0.996757 }, { \"Slot\":\"Slot08_Size1\", \"Item\":\"int_dockingcomputer_advanced\", \"On\":true, \"Priority\":4, \"Health\":0.981857 }, { \"Slot\":\"PlanetaryApproachSuite\", \"Item\":\"int_planetapproachsuite\", \"On\":true, \"Priority\":1, \"Health\":1.000000 }, { \"Slot\":\"VesselVoice\", \"Item\":\"voicepack_maksim\", \"On\":true, \"Priority\":1, \"Health\":1.000000 } ] }" },
            };
    }
}