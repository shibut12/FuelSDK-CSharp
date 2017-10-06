﻿using FuelSDK.MobilePush;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FuelSDK.Test
{
    [TestFixture()]
    class PushMessageTest
    {
        ETClient client;
        PushMessage pushMessage;

        [OneTimeSetUp]
        public void Setup()
        {
            client = new ETClient();
        }

        [SetUp]
        public void PushMessageSetup()
        {
            PushMessageKey pk = new PushMessageKey
            {
                Key = "testkey",
                Value = "new value set by SDK"
            };
            PushMessageKey[] keys = new PushMessageKey[] { pk };
            PushMessage msg = new PushMessage
            {
                AuthStub = client,
                MessageType = PushMessageType.Outbound,
                ContentType = PushMessageContentType.InboxAlert,
                Name = "SDK Test Message 10",
                Application = new PushMessageApplication
                {
                    Id = "8e6cbcd3-d554-4c05-b21e-7f05f5aeb2ae",
                    Name = "ru3nxj36e5ynufyn94dgy4jb"
                },
                Alert = "Test Alert Message",
                Badge = "+1",
                ContentAvailable = 1,
                StartDate = "2017-10-01T14:50:00Z",
                Status = PushMessageStatus.Draft,
                PageId = 23246,
                Keys = keys
            };

            pushMessage = PushMessage.CreatePushMessage(msg);
        }

        [TearDown]
        public void PushMessageTearDown()
        {
            if (pushMessage != null)
            {
                PushMessage.DeletePushMessage(client, pushMessage.Id);
            }
        }

        [Test()]
        public void CreatePushMessage()
        {
            Assert.IsNotNull(pushMessage);
        }

        [Test()]
        public void UpdatePushMessage()
        {
            pushMessage.AuthStub = client;
            pushMessage.Alert = "Updated alert message";
            var updatedMsg = PushMessage.UpdatePushMessage(pushMessage);
            Assert.IsNotNull(updatedMsg);
            Assert.IsTrue(pushMessage.Alert == updatedMsg.Alert);
        }

        [Test()]
        public void GetPushMessages()
        {
            var pushMsgs = PushMessage.GetPushMessages(client);
            Assert.IsNotNull(pushMsgs);
        }

        [Test()]
        public void GetPushMessage()
        {
            var pushMsg = PushMessage.GetPushMessage(client, pushMessage.Id);
            Assert.IsNotNull(pushMsg);
            Assert.IsTrue(pushMsg.Name == pushMessage.Name);
        }

        [Test()]
        public void DeletePushMessage()
        {
            var retVal = PushMessage.DeletePushMessage(client, pushMessage.Id);
            Assert.IsTrue(retVal);
            pushMessage = null;
        }
    }
}
