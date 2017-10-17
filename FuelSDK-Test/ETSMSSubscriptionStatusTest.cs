using NUnit.Framework;
using System;
using FuelSDK.SMS;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace FuelSDK.Test
{
    [TestFixture()]
    class ETSMSSubscriptionStatusTest
    {
        ETClient client;
        ETSMSSubscriptionStatus subscriptionStatus;
        string[] number;
        string[] skey;

        [OneTimeSetUp]
        public void Setup()
        {
            client = new ETClient();
        }

        [Test()]
        public void GetSubscriptionStatus()
        {
            Debug.WriteLine("Hello World!");
            Debug.WriteLine("Time {0}", DateTime.Now);

            subscriptionStatus = new ETSMSSubscriptionStatus();
            subscriptionStatus.MobileNumber = new[] { "13174891157" };
            subscriptionStatus.AuthStub = client;
            var result = subscriptionStatus.Post();
            var obj = result.Results[0];
            Debug.WriteLine(obj);
        }

    }
}
