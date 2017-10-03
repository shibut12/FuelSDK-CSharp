using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FuelSDK.SMS
{
    public class ETSMSKeyword : FuelObject
    {
        public string LongCode { get; set; }
        public string ShortCode { get; set; }
        public string CountryCode { get; set; }
        public string Keyword { get; set; }
        public string KeywordId { get; set; }

        public ETSMSKeyword()
        {
            Endpoint = "https://www.exacttargetapis.com/sms/v1/keyword";
            URLProperties = new string[0];
            RequiredURLProperties = new string[0];
        }

        public ETSMSKeyword(JToken obj)
        {
            if (obj[0]["KeywordId"] != null)
            {
                KeywordId = obj[0]["KeywordId"].ToString();
            }
        }

        public ETSMSKeywordResponse CreateKeyword()
        {
            if ( (ShortCode == null || ShortCode.Length == 0) && (LongCode == null || LongCode.Length == 0) )
            {
                throw new ApplicationException("Need at least ShortCode or LongCode to create keyword.");
            }
            if (CountryCode == null || CountryCode.Length == 0)
            {
                throw new ApplicationException("CountryCode is either null or empty. Need to specify CountryCode.");
            }
            if (Keyword == null || Keyword.Length == 0)
            {
                throw new ApplicationException("Keyword is either null or empty. Need to specify keyword.");
            }
            if (ShortCode != null && ShortCode.Length != 0 && LongCode != null && LongCode.Length != 0)
            {
                throw new ApplicationException("ShortCode and LongCode cannot be specified at the same time.");
            }
            ETSMSReturn smsreturn = new ETSMSReturn();
            return smsreturn.PerformKeywordOperation(this, "POST");
        }

        public ETSMSKeywordResponse DeleteKeyword()
        {
            if (KeywordId == null || KeywordId.Length == 0)
            {
                throw new ApplicationException("KeywordId is either null or empty. Need to specify KeywordId.");
            }
            Endpoint = "https://www.exacttargetapis.com/sms/v1/keyword/{KeywordId}";
            URLProperties = new[] { "KeywordId" };
            RequiredURLProperties = new[] { "KeywordId" };

            ETSMSReturn smsreturn = new ETSMSReturn();
            return smsreturn.PerformKeywordOperation(this, "DELETE");
            //return null;
        }
    
    }

}
