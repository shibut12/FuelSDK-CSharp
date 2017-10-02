using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace FuelSDK.Test
{
    class ETResultMessageTest
    {
        ETClient client;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            client = new ETClient();
        }

        [Test()]
        public void ETResultMessageGet()
        {
            ETResultMessage tsd = new ETResultMessage
            {
                AuthStub = this.client
            };
            var resp = tsd.Get();
            Assert.AreEqual(resp.Code, 200);
            Assert.AreEqual(resp.Status, true);

            var reqid = resp.RequestID;
            var status = resp.Status;
            var msg = resp.Message;
        }
    }
}
