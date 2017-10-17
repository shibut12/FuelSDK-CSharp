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
            GetAllLocationsTest();
            UpdateLocationTest();
            DeleteLocationTest();
        }

//        [Test()]
        public void CreateLocationTest()
        {
            MobilePushLocation loc = new MobilePushLocation
            {
                AuthStub = client,
                Name = "Location SF Tower",
                Location = "SF Tower Location on Ohio Street",
                Description = "111 Monument Cir #222, Indianapolis, IN 46204",
                Radius = 10,
                Center = new LocationCenter
                {
                    Latitude = 39.769624,
                    Longitude = -86.157063
                },
                Attributes = new LocationAttribute[] 
                {
                     new LocationAttribute{Attribute="Address 1", Value="111 Monument Cir"},
                     new LocationAttribute{Attribute="City", Value="Indianapolis"},
                     new LocationAttribute{Attribute="State", Value="IN"}
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

            var cloc = loc.GetLocation();
            Debug.WriteLine("Get Loc ID=" + cloc.LocationId);
            Assert.AreEqual(cloc.LocationId, locId);
        }

//        [Test()]
        public void GetAllLocationsTest()
        {
            MobilePushLocation loc = new MobilePushLocation
            {
                AuthStub = client,
            };

            MobilePushLocation[] locs = loc.GetLocations();
            foreach (MobilePushLocation gloc in locs)
            {
                Debug.WriteLine("Get Loc ID=" + gloc.LocationId);
                Assert.NotNull(gloc.LocationId);
            }
            
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
