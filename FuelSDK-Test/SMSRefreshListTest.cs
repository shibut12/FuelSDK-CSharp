using NUnit.Framework;
using System;
using FuelSDK;
using Newtonsoft.Json.Linq;
using FuelSDK.SMS;
using System.Net;
using System.Diagnostics;

namespace FuelSDK.Test
{
    [TestFixture()]
    public class SMSRefreshListTest
    {
        ETClient client;
        string listID = "e49d684d-2cbb-e711-80d3-1402ec6b9528";

        [OneTimeSetUp]
        public void Setup()
        {
            client = new ETClient();
        }

        [Test()]
        public void DoRefreshList()
        {
            SMSRefreshList smsrefresh = new SMSRefreshList
            {
                AuthStub = client,
                ListId = listID
            };
            var response = smsrefresh.RefreshList();
            Debug.WriteLine("Code=" + response.Code);
            Debug.WriteLine("TokenId=" + response.TokenId);

            Assert.Null(response.Error);
            Assert.NotNull(response.TokenId);
            Assert.NotNull(response.LastPublishDate);
        }
    }


}
