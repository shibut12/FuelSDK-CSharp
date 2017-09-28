using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace FuelSDK.Test
{
    class ETTriggeredSendSummaryTest
    {
        ETClient client;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            client = new ETClient();
        }

        [Test()]
        public void TriggeredSendSummaryGet()
        {
            ETTriggeredSendSummary tsd = new ETTriggeredSendSummary
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
