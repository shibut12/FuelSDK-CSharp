using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FuelSDK.SMS
{
    /// <summary>
    /// Class that represents SMS keyword.
    /// </summary>
    public class SMSKeyword : FuelObject
    {
        /// <summary>
        /// The long code that the keyword will be created on
        /// </summary>
        public string LongCode { get; set; }
        /// <summary>
        /// The short code that the keyword will be created on
        /// </summary>
        public string ShortCode { get; set; }
        /// <summary>
        /// The two letter country code specifying the country that short code belongs to
        /// </summary>
        public string CountryCode { get; set; }
        /// <summary>
        /// SMS Keyword
        /// </summary>
        public string Keyword { get; set; }
        /// <summary>
        /// Id of the keyword created.
        /// </summary>
        public string KeywordId { get; set; }
        /// <summary>
        /// Default contructor
        /// </summary>
        public SMSKeyword()
        {
            Endpoint = "https://www.exacttargetapis.com/sms/v1/keyword";
            URLProperties = new string[0];
            RequiredURLProperties = new string[0];
        }
        /// <summary>
        /// Creates a new keyword
        /// </summary>
        /// <returns>Id of the keyword created.</returns>
        public string CreateKeyword()
        {
            return SMSReturn.CreateKeyword(this);
        }
        /// <summary>
        /// Delete a keyword by its Id
        /// </summary>
        /// <param name="keywordId">Id of the keyword to be deleted</param>
        /// <returns>Response message as string</returns>
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
        /// <summary>
        /// Delete a keyword by the short code it associated to.
        /// </summary>
        /// <param name="keyword">Keyword to be deleted</param>
        /// <param name="shortCode">Short code to which the keyword associated to</param>
        /// <param name="countryCode">Country code to which the short code associated to</param>
        /// <returns>Response message as string</returns>
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
        /// <summary>
        /// Delete a keyword by the long code it associated to.
        /// </summary>
        /// <param name="keyword">Keyword to be deleted</param>
        /// <param name="longCode">Long code to which the keyword associated to</param>
        /// <returns></returns>
        public string DeleteKeywordByLongCode(string keyword, string longCode)
        {
            Keyword = keyword;
            ShortCode = longCode;
            Endpoint = "https://www.exacttargetapis.com/sms/v1/keyword/{Keyword}/{LongCode}";
            URLProperties = new[] { "Keyword", "LongCode"  };
            RequiredURLProperties = new[] { "Keyword", "LongCode" };
            return SMSReturn.DeleteKeywordByKeywordId(this);
        }
    
    }

}
