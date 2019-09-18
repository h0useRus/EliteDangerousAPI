using System;
using System.Collections.Generic;
using NSW.EliteDangerous.Events.Entities;
using Xunit;

namespace NSW.EliteDangerous.Events
{
    public class ScanEventTests
    {
        private const string EventName = "Scan";

        [Theory]
        [MemberData(nameof(Data))]
        public void ShouldExecuteEvent(string eventName, string json)
        {
            var api = (EliteDangerousAPI)TestHelpers.TestApi;
            var eventFired = false;
            api.Exploration.Scan += (sender, @event) =>
            {
                Assert.IsType<EliteDangerousAPI>(sender);
                AssertEvent(@event);
                eventFired = true;
            };

            Assert.True(api.HasEvent(eventName));
            AssertEvent(api.ExecuteEvent(eventName, json) as ScanEvent);
            Assert.True(eventFired);
        }

        private void AssertEvent(ScanEvent @event)
        {
            Assert.NotNull(@event);
            Assert.Equal(DateTime.Parse("2018-02-02T10:43:05Z"), @event.Timestamp);
            Assert.Equal(EventName, @event.Event);
            Assert.Equal(DiscoveryScanType.NavBeaconDetail, @event.ScanType);
            Assert.Equal("Procyon B 3 a", @event.BodyName);
            Assert.Equal(12, @event.BodyId);
            Assert.Equal(10048.152344, @event.DistanceFromArrivalLs, 6);
            Assert.True(@event.TidalLock);
            Assert.Equal(string.Empty, @event.TerraformState);
            Assert.Equal("Rocky body", @event.PlanetClass);
            Assert.Equal(string.Empty, @event.Atmosphere);
            Assert.Equal("None", @event.AtmosphereType);
            Assert.Equal(2, @event.AtmosphereComposition.Length);
            Assert.Equal("Hydrogen", @event.AtmosphereComposition[0].Name);
            Assert.Equal(74.043083, @event.AtmosphereComposition[0].Percent, 6);
            Assert.Equal(string.Empty, @event.Volcanism);
            Assert.Equal(0.025342, @event.MassEm, 6);
            Assert.Equal(2011975.250000, @event.Radius, 6);
            Assert.Equal(2.495225, @event.SurfaceGravity, 6);
            Assert.Equal(318.448792, @event.SurfaceTemperature, 6);
            Assert.Equal(0.000000, @event.SurfacePressure, 6);
            Assert.True(@event.Landable);
            Assert.Equal(11, @event.Materials.Length);
            Assert.Equal("iron", @event.Materials[0].Name);
            Assert.Equal(19.315084, @event.Materials[0].Percent, 6);
            Assert.Equal(0.000000, @event.Composition.Ice, 6);
            Assert.Equal(0.861282, @event.Composition.Rock, 6);
            Assert.Equal(0.138718, @event.Composition.Metal, 6);
            Assert.Equal(89655728.000000, @event.SemiMajorAxis, 6);
            Assert.Equal(0.000000, @event.Eccentricity, 6);
            Assert.Equal(4.566576, @event.OrbitalInclination, 6);
            Assert.Equal(309.656799, @event.Periapsis, 6);
            Assert.Equal(344902.937500, @event.OrbitalPeriod, 6);
            Assert.Equal(352425.468750, @event.RotationPeriod, 6);
            Assert.Equal(0.479157, @event.AxialTilt, 6);
            Assert.True(@event.WasMapped);
            Assert.True(@event.WasDiscovered);

            Assert.Equal(2, @event.Rings.Length);
            Assert.Equal("Imeut AB 2 A Ring", @event.Rings[0].Name);
            Assert.Equal("eRingClass_MetalRich", @event.Rings[0].RingClass);
            Assert.Equal(2.1371e+09, @event.Rings[0].MassMt);
            Assert.Equal(5.7442e+07, @event.Rings[0].InnerRad);
            Assert.Equal(6.0438e+07, @event.Rings[0].OuterRad);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { EventName,  "{ \"timestamp\":\"2018-02-02T10:43:05Z\", \"event\":\"Scan\", \"ScanType\":\"NavBeaconDetail\",\"BodyName\":\"Procyon B 3 a\", \"BodyID\":12, \"Parents\":[ {\"Planet\":11}, {\"Star\":2}, {\"Null\":0} ],\r\n\"DistanceFromArrivalLS\":10048.152344, \"TidalLock\":true, \"TerraformState\":\"\", \"PlanetClass\":\"Rocky body\",\r\n\"Atmosphere\":\"\", \"AtmosphereType\":\"None\", \"Volcanism\":\"\", \"MassEM\":0.025342, \"Radius\":2011975.250000,\r\n\"SurfaceGravity\":2.495225, \"SurfaceTemperature\":318.448792, \"SurfacePressure\":0.000000, \"Landable\":true,\r\n\"Materials\":[ { \"Name\":\"iron\", \"Percent\":19.315084 }, { \"Name\":\"sulphur\", \"Percent\":17.321133 }, {\r\n\"Name\":\"nickel\", \"Percent\":14.609120 }, { \"Name\":\"carbon\", \"Percent\":14.565277 }, { \"Name\":\"phosphorus\",\r\n\"Percent\":9.324941 }, { \"Name\":\"chromium\", \"Percent\":8.686635 }, { \"Name\":\"manganese\",\r\n\"Percent\":7.976933 }, { \"Name\":\"zinc\", \"Percent\":5.249117 }, { \"Name\":\"tin\", \"Percent\":1.200338 }, {\r\n\"Name\":\"tungsten\", \"Percent\":1.060592 }, { \"Name\":\"technetium\", \"Percent\":0.690823 } ], \"Composition\":{\r\n\"Ice\":0.000000, \"Rock\":0.861282, \"Metal\":0.138718 }, \"SemiMajorAxis\":89655728.000000, \"Eccentricity\":0.000000, \"OrbitalInclination\":4.566576, \"Periapsis\":309.656799, \"OrbitalPeriod\":344902.937500, \"RotationPeriod\":352425.468750, \"AxialTilt\":0.479157, \"Rings\":[ { \"Name\":\"Imeut AB 2 A Ring\", \"RingClass\":\"eRingClass_MetalRich\", \"MassMT\":2.1371e+09, \"InnerRad\":5.7442e+07, \"OuterRad\":6.0438e+07 }, { \"Name\":\"Imeut AB 2 B Ring\", \"RingClass\":\"eRingClass_Icy\", \"MassMT\":2.254e+10, \"InnerRad\":6.0538e+07, \"OuterRad\":8.5899e+07 } ],\"AtmosphereComposition\": [ { \"Name\": \"Hydrogen\", \"Percent\": 74.043083 }, { \"Name\": \"Helium\", \"Percent\": 25.956926 } ], \"WasDiscovered\": true, \"WasMapped\": true }" },
            };
    }
}