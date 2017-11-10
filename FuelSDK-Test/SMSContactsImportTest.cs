using FuelSDK.SMS;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FuelSDK.Test
{
    public class SMSContactsImportTest
    {
        ETClient client;
        string tokenId;

        [OneTimeSetUp]
        public void Setup()
        {
            client = new ETClient();
        }

        [SetUp]
        public void SMSContactsImportSetup()
        {
        }

        /// <summary>
        /// For this test to run successfully, an import file needs to be in the enhanced ftp site.
        /// </summary>
        [Test()]
        public void QueueContactsImport()
        {
            SMSContactsImportFieldMap fieldMap1 = new SMSContactsImportFieldMap
            {
                Destination = "_MobileNumber",
                Ordinal = 2,
                Source = "Mobile Number"
            };
            SMSContactsImportFieldMap fieldMap2 = new SMSContactsImportFieldMap
            {
                Destination = "_CountryCode",
                Ordinal = 3,
                Source = "Country Code"
            };
            SMSContactsImportFieldMap fieldMap3 = new SMSContactsImportFieldMap
            {
                Destination = "_SubscriberKey",
                Ordinal = 1,
                Source = "Subscriber Key"
            };
            SMSContactsImporter contactsImporter = new SMSContactsImporter
            {
                AuthStub = client,
                ListId = "9cc85cc3-90b9-e711-80d3-1402ec6b9528",
                ShortCode = "10766790",
                Keyword = "MC_SDK",
                SendEmailNotification = true,
                EmailAddress = "test@test.com",
                ImportMappingType = "MapByOrdinal",
                // make sure this file is in enhanced ftp site import folder before running the test
                FileName = "importtest.csv",
                FileType = "csv",
                IsFirstRowHeader = true,
                FieldMaps = new SMSContactsImportFieldMap[] { fieldMap1, fieldMap2, fieldMap3}
            };

            var resp = contactsImporter.QueueImport();
            Assert.IsNotNull(resp);
        }
    }
}
