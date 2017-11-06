using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FuelSDK.SMS
{
    /// <summary>
    /// SMSMessageList class represents an object that can initiate a message to one or more contact lists
    /// </summary>
    public class SMSMessageList : FuelObject
    {
        /// <summary>
        /// The encoded message ID
        /// </summary>
        public string MessageId { get; set; }
        /// <summary>
        /// An array of one or more List ID strings.
        /// </summary>
        public string[] TargetListIds { get; set; }
        /// <summary>
        /// An array of one or more List ID strings. The contacts in these Lists will be excluded.
        /// </summary>
        public string[] ExclusionListIds { get; set; }
        /// <summary>
        /// A flag indicating TargetListIds will be provided for overriding the message default Target List Ids
        /// </summary>
        public bool OverrideTemplateTargetLists { get; set; }
        /// <summary>
        /// A flag indicating ExclusionListIds will be provided for overriding the message default Exclusion List Ids
        /// </summary>
        public bool OverrideTemplateExclusionLists { get; set; }
        /// <summary>
        /// A flag indicating that exclusion lists (even the default message exclusion lists) will not be used in the send
        /// </summary>
        public bool IgnoreExclusionLists { get; set; }
        /// <summary>
        /// A flag indicating that the text provided should override the text stored with the Message
        /// </summary>
        public bool OverrideMessageText { get; set; }
        /// <summary>
        /// Required when OverrideMessageText is true
        /// </summary>
        public string MessageText { get; set; }
        /// <summary>
        /// Details about the window of time where messages should not be sent. 
        /// </summary>
        public SMSBlackoutWindow BlackoutWindow { get; set; }
        /// <summary>
        /// Date and Time in UTC that the message will go out.
        /// </summary>
        public DateTime SendTime { get; set; }
        /// <summary>
        /// The same mobile number may receive multiple texts if this value is true
        /// </summary>
        public bool AllowDuplication { get; set; }
        /// <summary>
        /// The URL of the media content sent via an MMS message
        /// </summary>
        public string ContentURL { get; set; }
        /// <summary>
        /// Token Id returned when SMS message send request sent. This token id is used to further track the status of the request.
        /// </summary>
        public string TokenId { get; set; }
        /// <summary>
        /// Default constructor. Initialize the default endpoint, URLProperties and requried URL properties.
        /// </summary>
        public SMSMessageList()
        {
            Endpoint = "https://www.exacttargetapis.com/sms/v1/messageList/{MessageId}/send";
            URLProperties = new string[1] { "MessageId" };
            RequiredURLProperties = new string[1] { "MessageId" };
        }

        /// <summary>
        /// Send message to list.
        /// </summary>
        /// <returns>If the request is valid, the API returns a token that can be used to make a follow-up call to check the status of the request</returns>
        public string SendMessageToList()
        {
            return SMSReturn.SendMessageToList(this);
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
            Endpoint = "https://www.exacttargetapis.com/sms/v1/messageList/{MessageId}/deliveries/{TokenId}";
            URLProperties = new string[2] { "MessageId", "TokenId" };
            RequiredURLProperties = new string[2] { "MessageId", "TokenId" };
            return SMSReturn.GetSMSMessageStatus(this);
        } 
    }
}
