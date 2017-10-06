using FuelSDK.MobilePush;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace FuelSDK.Test
{
    [TestFixture()]
    class MobilePushLocationTest
    {
        ETClient client;
        string locId;

        [OneTimeSetUp]
        public void Setup()
        {
            client = new ETClient();
        }

        [Test()]
        public void PushLocationTest()
        {
            CreateLocationTest();
            GetLocationTest();
            UpdateLocationTest();
            DeleteLocationTest();
        }

//        [Test()]
        public void CreateLocationTest()
        {
            MobilePushLocation loc = new MobilePushLocation
            {
                AuthStub = client,
                Name = "Location B",
                Location = "Main Location on Elm Street",
                Description = "Location at 123 Elm St, Nowhere, CA 00000",
                Radius = 50,
                Center = new LocationCenter
                {
                    Latitude = 30.750362,
                    Longitude = -95.374712
                },
                Attributes = new LocationAttribute[] 
                {
                     new LocationAttribute{Attribute="Address 1", Value="abcdefghijklm"},
                     new LocationAttribute{Attribute="City", Value="bla bla"},
                     new LocationAttribute{Attribute="State", Value="blah blah even more"}
                }
            };

            var cloc = loc.CreateLocation();
            locId = cloc.LocationId;
            Debug.WriteLine("Create Loc ID="+cloc.LocationId);
            Assert.NotNull(cloc.LocationId);
        }

//        [Test()]
        public void GetLocationTest()
        {
            MobilePushLocation loc = new MobilePushLocation
            {
                AuthStub = client,
                LocationId = locId
            };

            var cloc = loc.GetSpecificLocation();
            Debug.WriteLine("Get Loc ID=" + cloc.LocationId);
            Assert.AreEqual(cloc.LocationId, locId);
        }

//        [Test()]
        public void UpdateLocationTest()
        {
            MobilePushLocation loc = new MobilePushLocation
            {
                AuthStub = client,
                LocationId = locId,
                Name = "Location C",
                Center = new LocationCenter
                {
                    Latitude = 31.750362,
                    Longitude = -90.374712
                },                
                Radius = 10
            };

            var cloc = loc.UpdateLocation();
            Debug.WriteLine("Update=" + cloc);
            Assert.IsTrue(cloc);
        }

//        [Test()]
        public void DeleteLocationTest()
        {
            MobilePushLocation loc = new MobilePushLocation
            {
                AuthStub = client,
                LocationId = locId
            };

            var cloc = loc.DeleteLocation();
            Debug.WriteLine("Delete=" + cloc);
            Assert.IsTrue(cloc);
        }
    }
}
