using FuelSDK.SMS;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FuelSDK.Test
{
    public class SMSContactsImportAndSendTest
    {
        ETClient client;
        string tokenId;

        [OneTimeSetUp]
        public void Setup()
        {
            client = new ETClient();
        }

        [SetUp]
        public void SMSContactsImportAndSendSetup()
        {
        }

        /// <summary>
        /// For this test to run successfully, an import file needs to be in the enhanced ftp site.
        /// Update email address to receive email alert.
        /// </summary>
        [Test()]
        public void ImportContactsAndSendMessage()
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
            SMSImportDefinition importDef = new SMSImportDefinition
            {
                ImportType = "FILE",
                FileName = "importtest.csv",
                ImportMappingType = "MapByOrdinal",
                FieldMaps = new SMSContactsImportFieldMap[] { fieldMap1, fieldMap2, fieldMap3 }
            };
            SMSImportSender sender = new SMSImportSender
            {
                AuthStub = client,
                MessageId = "MjE6Nzg6MA",
                Keyword = "DBE05D",
                NotificationEmail = "test@test.com",
                IsDuplicationAllowed = true,
                Override = true,
                OverrideText = "SMS Import Sender Test Message",
                ImportDefinition = new SMSImportDefinition[1] { importDef }
            };

            var resp = sender.ImportAndSend();
            Assert.IsNotNull(resp);
        }
    }
}
