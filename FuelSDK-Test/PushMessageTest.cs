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
        
        [OneTimeSetUp]
        public void Setup()
        {
            client = new ETClient();
        }

        [Test()]
        public void CreatePushMessage()
        {
            PushMessage msg = new PushMessage
            {
                AuthStub = client,
                MessageType = PushMessageType.Outbound,
                ContentType = PushMessageContentType.InboxAlert,
                Name = "SDK Test Message 2",
                Application = new  PushMessageApplication 
                {
                    Id = "8e6cbcd3-d554-4c05-b21e-7f05f5aeb2ae",
                    Name = "ru3nxj36e5ynufyn94dgy4jb"
                },
                Alert = "Test Alert Message",
                Badge = "+1",
                ContentAvailable = 1,
                StartDate = "2017-10-01T14:50:00Z",
                TZPastSendAction = "0",
                Status = PushMessageStatus.Draft,
                PageId = 23246
            };

            var pushMsg = PushMessage.CreatePushMessage(msg);
            Assert.IsNotNull(pushMsg);
            
            
        }
    }
}
