using FuelSDK.MobilePush;
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

        [Test()]
        public void SendPushMessage()
        {
            PushMessageSendObject msgObj = new PushMessageSendObject
            {
                AuthStub = client
            };
            msgObj.MessageId = "NTE6MTE0OjA";
            msgObj.OverrideMessageText = "You won million dollars";
            msgObj.SendTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            var retval = PushMessage.SendPushMessage(msgObj);
            Assert.IsTrue(retval);

        }

        [Test()]
        public void SendPushMessageToList()
        {
            PushMessageSendObject msgObj = new PushMessageSendObject
            {
                AuthStub = client
            };
            msgObj.MessageId = "NTE6MTE0OjA";
            msgObj.OverrideMessageText = "Have a safe drive!";
            msgObj.InclusionListIds = new string[] { "ce3b32fb-77af-e711-80d3-1402ec6b9528" };
            msgObj.SendTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm"); ;
            var retval = PushMessage.SendPushMessage(msgObj);
            Assert.IsTrue(retval);

        }

        [Test()]
        public void SendPushMessageToTagUser()
        {
            PushMessageSendObject msgObj = new PushMessageSendObject
            {
                AuthStub = client
            };
            msgObj.MessageId = "NTE6MTE0OjA";
            msgObj.OverrideMessageText = "Have a safe drive!";
            msgObj.InclusionTags = new string[] { "ALL6 More" };
            msgObj.SendTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            var retval = PushMessage.SendPushMessageToTaggedUsers(msgObj);
            Assert.IsTrue(retval);

        }

        [Test()]
        public void SendPushMessageToDevices()
        {
            PushMessageSendObject msgObj = new PushMessageSendObject
            {
                AuthStub = client
            };
            msgObj.MessageId = "NjA6MTE0OjA";    //"NTE6MTE0OjA";
            msgObj.OverrideMessageText = "Send using device token!";
            msgObj.DeviceTokens = new string[] { "2e5964ddeeb19c53ba407b075d34d6e4b8f719e143d10a37ca9f254d224ef457" };
            //msgObj.SubscriberKeys = new string[] { "sharifahmed" };
            msgObj.SendTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            var retval = PushMessage.SendPushMessageToDevices(msgObj);
            Assert.IsTrue(retval);
        }

        [Test()]
        public void SendPushMessageBatch()
        {
            PushMessageSendObject msgObj1 = new PushMessageSendObject();
            msgObj1.MessageId = "NjA6MTE0OjA";
            msgObj1.OverrideMessageText = "Have a safe drive!";
            msgObj1.DeviceTokens = new string[] { "2e5964ddeeb19c53ba407b075d34d6e4b8f719e143d10a37ca9f254d224ef457" };
            msgObj1.SendTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm");

            PushMessageSendObject msgObj2 = new PushMessageSendObject();
            msgObj2.MessageId = "NjA6MTE0OjA";
            msgObj2.OverrideMessageText = "Have a safe drive!";
            msgObj2.SubscriberKeys = new[] { "SivakumarMunuswami" };
            msgObj2.SendTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            var payload = new PushMessageSendObject[] { msgObj1, msgObj2 };

            var retVal = PushMessage.SendPushMessageBatch(client, msgObj1.MessageId, payload);
            Assert.IsTrue(retVal);
        }

    }
}
