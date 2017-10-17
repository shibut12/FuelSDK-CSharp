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
    class MobilePushCustomKeyTest
    {
        ETClient client;
        string appId;
        string keyname;

        [OneTimeSetUp]
        public void Setup()
        {
            client = new ETClient();
            appId = "8e6cbcd3-d554-4c05-b21e-7f05f5aeb2ae";
            keyname = System.Guid.NewGuid().ToString().Substring(0, 5);
        }

        [Test()]
        public void CustomKeyTest()
        {
            CreateCustomKeyTest();
            GetCustomKeyTest();
            UpdateCustomKeyTest();
            DeleteCustomKeyTest();

            keyname = System.Guid.NewGuid().ToString().Substring(0, 5);
            CreateCustomKeyTest();
            DeleteOneCustomKeyTest();

        }

//        [Test()]
        public void GetCustomKeyTest()
        {
            MobilePushCustomKey ckey = new MobilePushCustomKey
            {
                AuthStub = client,
                ApplicationId = appId
            };

            var k = ckey.GetCustomKeys();
            Debug.WriteLine("keys=" + k);
            Assert.IsNotNull(k);
        }

//        [Test()]
        public void DeleteCustomKeyTest()
        {
            MobilePushCustomKey ckey = new MobilePushCustomKey
            {
                AuthStub = client,
                ApplicationId = appId
            };

            var b = ckey.DeleteCustomKeys();
            Debug.WriteLine("Delete=" + b);
            Assert.IsTrue(b);
        }

        public void DeleteOneCustomKeyTest()
        {
            MobilePushCustomKey ckey = new MobilePushCustomKey
            {
                AuthStub = client,
                ApplicationId = appId,
                KeyName = this.keyname
            };

            var b = ckey.DeleteCustomKey();
            Debug.WriteLine("Delete1=" + b);
            Assert.IsTrue(b);
        }

//        [Test()]
        public void CreateCustomKeyTest()
        {
            MobilePushCustomKey ckey = new MobilePushCustomKey
            {
                AuthStub = client,
                ApplicationId = appId,
                KeyName = this.keyname
            };

            var b = ckey.CreateCustomKey();
            Debug.WriteLine("Create=" + b);
            Assert.IsTrue(b);
        }

//        [Test()]
        public void UpdateCustomKeyTest()
        {
            MobilePushCustomKey ckey = new MobilePushCustomKey
            {
                AuthStub = client,
                ApplicationId = appId,
                KeyName = this.keyname,
                Description = "Text that describes the key"
            };

            var b = ckey.UpdateCustomKey();
            Debug.WriteLine("Update=" + b);
            Assert.IsTrue(b);
        }

    }
}
