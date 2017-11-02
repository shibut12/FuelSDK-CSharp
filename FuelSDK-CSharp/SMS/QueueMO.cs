using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FuelSDK.SMS
{
    /// <summary>
    /// QueueMO class helps to queue mobile originated message.
    /// 
    /// The mobileNumbers value accepts only 250 or fewer normalized phone numbers. 
    /// The subscribers value accepts only 250 or fewer string values (including 1 to 254 characters). 
    /// You can use a single subscriberkey value with multiple mobileNumber values, depending on how your account manages contact information. 
    /// You must provide values for either mobileNumbers or subscribers, but not both. 
    /// If you populate both arrays, the API defaults to use subscriber information and ignores mobileNumbers information.
    /// The mobileNumbers value must be no fewer than eight and no more than 15 characters. 
    /// The mobileNumbers value must also use the correct format for the designated country code. 
    /// For example, a phone number from the United States must include the numeric country code 1 and the applicable area code as displayed in the sample CSV file. 
    /// Note that the numeric country code mentioned here applies only to the phone number itself, and that any separate field containing country code information must conform to ISO-3306-1 alpha-2 standards.
    /// </summary>
    public class QueueMO : FuelObject
    {
        /// <summary>
        /// An array of mobile numbers used in the send. 
        /// Either the mobileNumbers or subscribers property is required, but not both.
        /// </summary>
        public string[] MobileNumbers { get; set; }
        /// <summary>
        /// An array of subscriber keys and mobile numbers used in the send. 
        /// Either the mobileNumbers or subscribers property is required, but not both.
        /// </summary>
        public SMSSubscriber[] Subscribers { get; set; }
        /// <summary>
        /// SMS short code
        /// </summary>
        public string ShortCode { get; set; }
        /// <summary>
        /// SMS text message.
        /// </summary>
        public string MessageText { get; set; }
        /// <summary>
        /// Token Id returned from successfull queue request.
        /// </summary>
        [JsonIgnore]
        public string TokenId { get; set; }
        /// <summary>
        /// Default constructor
        /// </summary>
        public QueueMO()
        {
            Endpoint = "https://www.exacttargetapis.com/sms/v1/queueMO";
            URLProperties = new string[0];
            RequiredURLProperties = new string[0];
        }
        /// <summary>
        /// Queue MO message for the provided subscribers.
        /// </summary>
        /// <returns>QueueMOResponse object <see cref="T:namespace FuelSDK.SMS.QueueMOResponse"/></returns>
        public QueueMOResponse QueueMOForSubscribers()
        {
            if (Subscribers == null || Subscribers.Length == 0)
            {
                throw new ApplicationException("Subscriber list is either null or empty. Need at least one subscriber to queue.");
            }
            MobileNumbers = null;
            return SMSReturn.QueueMO(this);
        }
        /// <summary>
        /// Queue MO message for the provided mobile numbers.
        /// </summary>
        /// <returns>QueueMOResponse object <see cref="T:namespace FuelSDK.SMS.QueueMOResponse"/></returns>
        public QueueMOResponse QueueMOForMobileNumbers()
        {
            if (MobileNumbers == null || MobileNumbers.Length == 0)
            {
                throw new ApplicationException("Mobile numbers is either null or empty. Need at least one mobile number to queue.");
            }
            Subscribers = null;
            return SMSReturn.QueueMO(this);
        }

        /// <summary>
        /// Get Queue MO message status.
        /// </summary>
        /// <param name="tokenId">Token Id received during successfull Queue MO request for which status is requested.</param>
        /// <returns>Array of Tracking information for each mobile numbers.<see cref="T:namespace FuelSDK.SMS.SMSTracking"/></returns>
        public SMSTracking[] GetDeliveryStatus(string tokenId)
        {
            TokenId = tokenId;
            Endpoint = "https://www.exacttargetapis.com/sms/v1/queueMO/deliveries/{TokenId}";
            URLProperties = new string[1] { "TokenId" };
            RequiredURLProperties = new string[1] { "TokenId" };
            return SMSReturn.GetQueueMODeliveryStatus(this);

        }
    }
}
