using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FuelSDK.SMS
{
    public class ETQueueMO : FuelObject
    {
        public string[] MobileNumbers { get; set; }
        public ETSMSSubscriber[] Subscribers { get; set; }
        public string ShortCode { get; set; }
        public string MessageText { get; set; }
        public string Identifier { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }

        public ETQueueMO()
        {
            Endpoint = "https://www.exacttargetapis.com/sms/v1/queueMO";
            URLProperties = new string[0];
            RequiredURLProperties = new string[0];
        }

        public ETQueueMO(JToken obj)
        {
            if (obj[0]["identifier"] != null)
            {
                Identifier = obj[0]["identifier"].ToString();
            }
            if (obj[0]["mobileNumbers"] != null)
            {
                MobileNumbers = obj[0]["mobileNumbers"].ToObject<string[]>();
            }
            if (obj[0]["subscribers"] != null)
            {
                Subscribers = obj[0]["subscribers"].ToObject<ETSMSSubscriber[]>();
            }
        }

        public PostReturn QueueMOForSubscribers()
        {
            if (Subscribers == null || Subscribers.Length == 0)
            {
                throw new ApplicationException("Subscriber list is either null or empty. Need at least one subscriber to queue.");
            }
            return new PostReturn(this);
        }

        public ETQueueMOResponse QueueMOForMobileNumbers()
        {
            if (MobileNumbers == null || MobileNumbers.Length == 0)
            {
                throw new ApplicationException("Mobile numbers is either null or empty. Need at least one mobile number to queue.");
            }
            ETSMSReturn smsreturn = new ETSMSReturn();
            return smsreturn.QueueMO(this);
        }
    }
}
