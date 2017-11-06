using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FuelSDK.SMS
{
    /// <summary>
    /// Class that represent the object sent while intiating a message send to one or more mobile numbers.
    /// </summary>
    public class SMSMessageContact : FuelObject
    {
        /// <summary>
        /// The encoded message ID
        /// </summary>
        public string MessageId { get; set; }
        /// <summary>
        /// An array of one or more mobile numbers
        /// </summary>
        public string[] MobileNumbers { get; set; }
        /// <summary>
        /// Array of up to 250 subscriber records where the message is sent to. 
        /// Subscribers is different from mobileNumbers because it allows you to specify a 
        /// SubscriberKey value and the mobile number as the unique identifier for that record.
        /// <see cref="T:FuelSDK.SMS.SMSSubscriber"/>
        /// </summary>
        public SMSSubscriber[] Subscribers { get; set; }
        /// <summary>
        /// Flag to indicate a subscription should be created if none exist
        /// </summary>
        public bool Subscribe { get; set; }
        /// <summary>
        /// Flag to indicate a subscription should be reset if currently unsubscribed
        /// </summary>
        public bool Resubscribe { get; set; }
        /// <summary>
        /// The keyword must align with code on message. Required when subscribe and/or resubscribe are true.
        /// </summary>
        public string Keyword { get; set; }
        /// <summary>
        /// Flag to indicate that the contact is receive the messageText as provided instead of the message's original text
        /// </summary>
        public bool Override { get; set; }
        /// <summary>
        /// Text value to be used in place of the message's original text. This value is required when override is true.
        /// </summary>
        public string MessageText { get; set; }
        /// <summary>
        /// Details about the window of time where messages should not be sent. 
        /// Messages initiated inside of this window will be queued and delivered once the window is open.
        /// </summary>
        public SMSBlackoutWindow BlackoutWindow { get; set; }
        /// <summary>
        /// Date and Time in UTC that the message will go out.
        /// This property is ignored during request, instead MessageSendTime which is formatted string of SendTime property is sent.
        /// </summary>
        [JsonIgnore]
        public DateTime SendTime { get; set; }
        /// <summary>
        /// Formatted SendTime property.  
        /// </summary>
        [JsonProperty(PropertyName = "SendTime")]
        public string MessageSendTime { get { return SendTime.ToString("yyyy-MM-dd HH:mm"); } private set { } }
        /// <summary>
        /// The URL of the media content sent via an MMS message
        /// </summary>
        public string ContentURL { get; set; }
        /// <summary>
        /// Token Id returned when SMS message send request sent. This token id is used to further track the status of the request.
        /// </summary>
        public string TokenId { get; set; }
        /// <summary>
        /// Default contructor
        /// </summary>
        public SMSMessageContact()
        {
            Endpoint = "https://www.exacttargetapis.com/sms/v1/messageContact/{MessageId}/send";
            URLProperties = new string[1] { "MessageId" };
            RequiredURLProperties = new string[1] { "MessageId" };
        }
        /// <summary>
        /// Initiates a message to one or more mobile numbers.
        /// </summary>
        /// <returns>If the request is valid, the API returns a token that can be used to make a follow-up call to check the status of the request</returns>
        public string SendMessage()
        {
            return SMSReturn.SendMessageToMobileNumbers(this);
        }
        /// <summary>
        /// Retrieves the overall delivery status of a message to a contact.
        /// </summary>
        /// <param name="messageId">Message Id provided for the messageContact</param>
        /// <param name="tokenId">Token Id returned for the messageContact</param>
        /// <returns>SMS message status.<see cref="T:FuelSDK.SMS.SMSMessageStatus"/></returns>
        public SMSMessageStatus GetDeliveryStatus(string messageId, string tokenId)
        {
            TokenId = tokenId;
            MessageId = messageId;
            Endpoint = "https://www.exacttargetapis.com/sms/v1/messageContact/{MessageId}/deliveries/{TokenId}";
            URLProperties = new string[2] { "MessageId", "TokenId" };
            RequiredURLProperties = new string[2] { "MessageId", "TokenId" };
            return SMSReturn.GetSMSMessageStatus(this);
        }
    }
}
