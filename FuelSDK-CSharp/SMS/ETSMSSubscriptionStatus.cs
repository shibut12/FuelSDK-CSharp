using System;
using Newtonsoft.Json.Linq;

namespace FuelSDK.SMS
{
    public class ETSMSSubscriptionStatus : FuelObject
    {
        public string[] MobileNumber { get; set; }
        public string[] SubscriberKey { get; set; }

        public int Count { get; set; }
        public DateTime CompleteDate { get; set; }

        public ETSMSSubscriptionStatus() 
        {
            Endpoint = "https://www.exacttargetapis.com//sms/v1/contacts/subscriptions";
            URLProperties = new string[0];
            RequiredURLProperties = new string[0];
        }

        public ETSMSSubscriptionStatus(JObject obj)
        {
            if (obj["count"] != null)
                Count = int.Parse(CleanRestValue(obj["count"]));
            if (obj["createDate"] != null)
                CreatedDate = DateTime.Parse(CleanRestValue(obj["createDate"]));
            if (obj["completeDate"] != null)
                CompleteDate = DateTime.Parse(CleanRestValue(obj["completeDate"]));

        }

        public GetReturn Get() { var r = new GetReturn(this); return r; }

        public PostReturn Post() { return new PostReturn(this); }
    }
}
