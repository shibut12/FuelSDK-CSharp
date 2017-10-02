using NUnit.Framework;
using System;
using FuelSDK;
using Newtonsoft.Json.Linq;
using FuelSDK.SMS;
using System.Net;

namespace FuelSDK.Test
{
    [TestFixture()]
    public class ETQueueMOTest
    {

        ETClient client;
        ETQueueMO queue;
        


        [OneTimeSetUp]
        public void Setup()
        {
            client = new ETClient();
        }

        

        [Test()]
        public void QueueMessageForMobileNumbers()
        {
            queue = new ETQueueMO
            {
                AuthStub = client,
                MobileNumbers = new[] { "19493091364","14437254123" },
                MessageText = "TESTCODE",
                ShortCode = "47200"
            };
            var response = queue.QueueMOForMobileNumbers();
            Assert.AreEqual(response.Code, HttpStatusCode.Accepted); 
        }

    }


}
