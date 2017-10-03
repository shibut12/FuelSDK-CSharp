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
    public class ETSMSKeywordTest
    {
        ETClient client;
        ETSMSKeyword smskey;
        string random;
        string keywordId;

        [OneTimeSetUp]
        public void Setup()
        {
            client = new ETClient();
            random = Guid.NewGuid().ToString().Replace("-", string.Empty).Replace("+", string.Empty).Substring(0, 6);
        }

        [Test()]
        public void CreateKeywordTest()
        {
            smskey = new ETSMSKeyword
            {
                AuthStub = client,
                Keyword = random,
                CountryCode = "US",
                ShortCode = "29860"
            };
            
            var response = smskey.CreateKeyword();
            Debug.WriteLine("Code=" + response.Code);
            Debug.WriteLine("KeywordId=" + response.KeywordId);
            Debug.WriteLine("Error=" + response.Error);
            Debug.WriteLine("Keyword=" + random);
            keywordId = response.KeywordId;

            Assert.AreEqual(response.Code, HttpStatusCode.Accepted);
            Assert.NotNull(response.KeywordId);
            Assert.Null(response.Error);
        }

 /*       [Test()]
        public void DeleteKeywordTest()
        {
            smskey = new ETSMSKeyword
            {
                AuthStub = client,
                KeywordId = keywordId
            };
            var response = smskey.DeleteKeyword();
            Debug.WriteLine("Code=" + response.Code);
            Assert.AreEqual(response.Code, HttpStatusCode.Accepted);
            Assert.NotNull(response.Status);
            Assert.Null(response.Error);
        }
        */
    }
}
