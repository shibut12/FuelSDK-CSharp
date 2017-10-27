using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

namespace FuelSDK.SMS
{
    public class SMSOptInMessage : FuelObject
    {
        public string LongCode { get; set; }
        public string ShortCode { get; set; }
        public string MessageName { get; set; }
        public string CountryCode { get; set; }
        public string Keyword { get; set; }
        public string MessageOptInType { get; set; }
        public string ResponseMessage { get; set; }
        public string DoubleOptInInitialMessage { get; set; }
        public string DoubleOptInConformationMessage { get; set; }
        public string DoubleOptInValidResponses { get; set; }
        public string OptInInvalidAgeMessage { get; set; }
        public int MinimumAge { get; set; }
        public bool AllowSingleOptIn  { get; set; }
        public string DuplicateOptInMessage { get; set; }
        public string OptInErrorMessage { get; set; }
        public string NextKeyword { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string MessageID { get; set; }

        public SMSOptInMessage()
        {
            Endpoint = "https://www.exacttargetapis.com/sms/v1/message/optin";
            URLProperties = new string[0];
            RequiredURLProperties = new string[0];
        }

        public ETSMSOptInResponse CreateOptInMessage()
        {
            SMSReturn smsreturn = new SMSReturn();
            return smsreturn.CreateOptInMessage(this, "POST");
        }
    }
}
