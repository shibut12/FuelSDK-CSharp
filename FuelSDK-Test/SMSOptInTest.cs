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
    public class SMSOptInTest
    {
        ETClient client;
        string keyword = "MC_SDK";
        string shortCode = "10766790";
        string countryCode = "US";

        [OneTimeSetUp]
        public void Setup()
        {
            client = new ETClient();
            //random = Guid.NewGuid().ToString().Replace("-", string.Empty).Replace("+", string.Empty).Substring(0, 6);
        }

        [Test()]
        public void CreateOptIn()
        {
            SMSOptInMessage smsopt = new SMSOptInMessage
            {
                AuthStub = client,
                Keyword = keyword,
                CountryCode = countryCode,
                ShortCode = shortCode,
                MessageName = "Example Message Name",
                MessageOptInType = "Single",
                ResponseMessage = "Hey, thanks for subscribing!",
                OptInErrorMessage = "An error occurred. Please try again."

            };

            var response = smsopt.CreateOptInMessage();
            Debug.WriteLine("Code=" + response.Code);
            Debug.WriteLine("Error=" + response.Error);
        }
    }
}
