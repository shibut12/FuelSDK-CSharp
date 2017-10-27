using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FuelSDK.SMS
{
    public class SMSKeyword : FuelObject
    {
        public string LongCode { get; set; }
        public string ShortCode { get; set; }
        public string CountryCode { get; set; }
        public string Keyword { get; set; }
        public string KeywordId { get; set; }
        public SMSKeyword()
        {
            Endpoint = "https://www.exacttargetapis.com/sms/v1/keyword";
            URLProperties = new string[0];
            RequiredURLProperties = new string[0];
        }

        public string CreateKeyword()
        {
            return SMSReturn.CreateKeyword(this);
        }

        public string DeleteKeywordByKeywordId(string keywordId)
        {
            KeywordId = keywordId;
            if (KeywordId == null || KeywordId.Length == 0)
            {
                throw new ApplicationException("KeywordId is either null or empty. Need to specify KeywordId.");
            }
            Endpoint = "https://www.exacttargetapis.com/sms/v1/keyword/{KeywordId}";
            URLProperties = new[] { "KeywordId" };
            RequiredURLProperties = new[] { "KeywordId" };
            return SMSReturn.DeleteKeywordByKeywordId(this);
        }

        public string DeleteKeywordByShortCode(string keyword, string shortCode, string countryCode)
        {
            Keyword = keyword;
            ShortCode = shortCode;
            CountryCode = countryCode;
            
            Endpoint = "https://www.exacttargetapis.com/sms/v1/keyword/{Keyword}/{ShortCode}/{CountryCode}";
            URLProperties = new[] { "Keyword","ShortCode","CountryCode" };
            RequiredURLProperties = new[] { "Keyword", "ShortCode", "CountryCode" };
            return SMSReturn.DeleteKeywordByKeywordId(this);
        }

        public string DeleteKeywordByLongCode(string keyword, string longCode)
        {
            Keyword = keyword;
            ShortCode = longCode;
            Endpoint = "https://www.exacttargetapis.com/sms/v1/keyword/{Keyword}/{LongCode}";
            URLProperties = new[] { "Keyword", "LongCode"  };
            RequiredURLProperties = new[] { "Keyword", "LongCode" };
            return SMSReturn.DeleteKeywordByKeywordId(this);
        }

        public ETSMSKeywordResponse DeleteKeywordByShortCode()
        {
            if (ShortCode == null || ShortCode.Length == 0)
            {
                throw new ApplicationException("ShortCode is either null or empty. Need to specify ShortCode.");
            }
            if (Keyword == null || Keyword.Length == 0)
            {
                throw new ApplicationException("Keyword is either null or empty. Need to specify Keyword.");
            }
            if (CountryCode == null || CountryCode.Length == 0)
            {
                throw new ApplicationException("CountryCode is either null or empty. Need to specify CountryCode.");
            }

            Endpoint = "https://www.exacttargetapis.com/sms/v1/keyword/{Keyword}/{ShortCode}/{CountryCode}";
            URLProperties = new[] { "Keyword", "ShortCode", "CountryCode" };
            RequiredURLProperties = new[] { "Keyword", "ShortCode", "CountryCode" };

            SMSReturn smsreturn = new SMSReturn();
            return smsreturn.PerformKeywordOperation(this, "DELETE");
        }
    
    }

}
