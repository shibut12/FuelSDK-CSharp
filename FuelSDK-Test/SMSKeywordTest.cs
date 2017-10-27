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

        [Test()]
        public void CreateOptInTest()
        {
            SMSOptInMessage smsopt = new SMSOptInMessage
            {
                AuthStub = client,
                Keyword = random,
                CountryCode = "US",
                ShortCode = "29860",
                MessageName = "AWESOMEYOU05dbd8",
                MessageOptInType = "Single",
                ResponseMessage = "Hey, thanks for subscribing!",
                OptInErrorMessage = "An error occurred. Please try again."

            };

            var response = smsopt.CreateOptInMessage();
            Debug.WriteLine("Code=" + response.Code);
            Debug.WriteLine("Error=" + response.Error);
            //Debug.WriteLine("Keyword=" + random);
            //keywordId = response.KeywordId;

            //Assert.AreEqual(response.Code, HttpStatusCode.Accepted);
            //Assert.NotNull(response.KeywordId);
            Assert.NotNull(response.Error);
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
