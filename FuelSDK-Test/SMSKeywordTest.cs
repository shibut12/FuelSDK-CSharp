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
    public class SMSKeywordTest
    {
        ETClient client;
        SMSKeyword smskey;
        string random;
        string keywordId;
        string shortCode = "10766790";
        string countryCode = "US";
        [OneTimeSetUp]
        public void Setup()
        {
            client = new ETClient();
            random = Guid.NewGuid().ToString().Replace("-", string.Empty).Replace("+", string.Empty).Substring(0, 6);
        }

        [Test()]
        public void CreateKeyword()
        {
            keywordId = CreateKeywordInternal();
            Assert.NotNull(keywordId);
        }

        [Test()]
        public void DeleteKeywordByKeywordId()
        {
            keywordId = CreateKeywordInternal();
            var response = smskey.DeleteKeywordByKeywordId(keywordId);
            Assert.NotNull(response);
        }

        [Test()]
        public void DeleteKeywordByShortCode()
        {
            keywordId = CreateKeywordInternal();
            var response = smskey.DeleteKeywordByShortCode(random, shortCode, countryCode);
            Assert.NotNull(response);
        }

        private string CreateKeywordInternal()
        {
            smskey = new SMSKeyword
            {
                AuthStub = client,
                Keyword = random,
                CountryCode = countryCode,
                ShortCode = shortCode
            };
            return smskey.CreateKeyword();
        }

    }
}
