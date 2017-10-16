using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FuelSDK.MobilePush
{
    /// <summary>
    /// PushMessage class represents the push message object
    /// </summary>
    public class PushMessage : MobilePushBase
    {
        /// <summary>
        /// Get or Set the Id of the PushMessage object
        /// </summary>
        /// <value>Id of the PushMessage object</value>
        public string Id { get; set; }
        /// <summary>
        /// Get or Set push message type. 
        /// Indicates the type of message to create.
        /// Outbound = 1,
        /// LocationEntry = 3,
        /// LocationExit = 4,
        /// Beacon = 5,
        /// Inbox = 8
        /// </summary>
        /// <value>Push message type <see cref="T:FuelSDK.MobilePush.PushMessageType"/></value>
        public PushMessageType MessageType { get; set; }
        /// <summary>
        /// Get or set push message content type. 
        /// Indicates the content included within the message using 
        /// the following integer values: 1 - Alert (default), 2 - Inbox, 3 - Inbox+Alert
        /// </summary>
        /// <value>Push message content type.<see cref="T:FuelSDK.MobilePush.PushMessageContentType"/></value>
        public PushMessageContentType ContentType { get; set; }
        /// <summary>
        /// Get or Set Name of the push message.
        /// String value indicating the name of the message. Must use 100 or less characters.
        /// </summary>
        /// <value>Name of the push message</value>
        public string Name { get; set; }
        /// <summary>
        /// Get or Set the application used to send message.
        /// see cref="T:FuelSDK.MobilePush.PushMessageApplication"/>
        /// </summary>
        /// <value>Push message application</value>
        public PushMessageApplication Application { get; set; }
        /// <summary>
        /// Get or Set the message displayed on the mobile device.
        /// </summary>
        /// <value>Alert message</value>
        public string Alert { get; set; }
        /// <summary>
        /// Get or Set sound file to play.
        /// Indicates the sound file to play when the push message arrives on the mobile device. 
        /// Name must include 100 or less characters.
        /// </summary>
        /// <value>Sound file name</value>
        public string Sound { get; set; }
        /// <summary>
        /// Get or Set badge count.
        /// The badge count displays a number in a badge on the app for iOS devices. 
        /// Assigned value must include 10 or less characters.
        /// </summary>
        /// <value>Badge count</value>
        public string Badge { get; set; }
        /// <summary>
        /// Get or Set content available falg.
        /// Integer value indicating the availability of content for an application enabled to use background push. 
        /// Set this value to 1 to indicate available content. 
        /// This parameter applies only to apps integrated with the background push functionality available in iOS. 
        /// Note that you can use background push functionality in all apps with iOS 7 and Newsstand apps in iOS 6.
        /// </summary>
        [JsonProperty(PropertyName = "content-available")]
        public int ContentAvailable { get; set; }
        /// <summary>
        /// Get or Set open direct location.
        ///  This value determines the location within the app that an app user views when they 
        ///  open that app via a push message. Assigned values must include 15 or less characters.
        /// </summary>
        /// <value>Open direct location</value>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string OpenDirect { get; set; }
        /// <summary>
        /// Get or Set custom keys value array.
        /// Used to override the value on the push message definition. 
        /// An array of Key/Value pairs that correspond to customer values defined in MobilePush.
        /// </summary>
        /// <value>Custom keys value array</value>
        public PushMessageKey[] Keys { get; set; }
        /// <summary>
        /// Get or Set custom request body. 
        /// Specify the actual request body of the push message to precisely align that request body to your specifications.
        /// </summary>
        /// <value>Custom request body</value>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public object Custom { get; set; }
        /// <summary>
        /// Get or Set Send Initiator
        /// Indicates the method used to initiate the send for a push message using 
        /// the following integer values: 0 - UI-based send, 1 - API (default), 2 - Automation, 3 - Journey Builder
        /// Inside SDK, only 1- API is acceptable value.
        /// </summary>
        public int SendInitiator { get; private set; }
        /// <summary>
        /// Get or Set Start Date
        /// Date and time when the message becomes available for sends. Uses a default value of the message creation time.
        /// </summary>
        /// <value>Start date</value>
        public string StartDate { get; set; }
        /// <summary>
        /// Get or Set End Date
        /// Date and time when the message is no longer available for sends. 
        /// This optional parameter applies only to messages whose contentType is CloudPage or Alert+CloudPage. 
        /// EndDate must be after startDate.
        /// </summary>
        /// <value>End date</value>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string EndDate { get; set; }
        /// <summary>
        /// Get or Set message status.
        /// Indicates the status of the message using the following integer values:
        /// 1 - Draft, 2 - Active (default), 3 - Inactive, 4 - Deleted
        /// </summary>
        /// <value>Push message status <see cref="T:FuelSDK.MobilePush.PushMessageStatus"/></value>
        public PushMessageStatus Status { get; set; }
        /// <summary>
        /// Get or Set Cloud page id.
        /// Integer values indicating the page associated with the message for CloudPage and Alert+CloudPage sends
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? PageId { get; set; }
        /// <summary>
        /// Get or Set the Url.
        /// String value indicating the URL for the page associated with the message for CloudPage and Alert+CloudPage sends
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Url { get; set; }
        /// <summary>
        /// Get or Set subject line.
        /// String value indicating the subject line used for the message
        /// </summary>
        /// <value>Message subject</value>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Subject { get; set; }
        /// <summary>
        /// Get or Set array of geofences.
        /// Array of string values indicating the geofences associated with the message send.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string[] GeoFences { get; set; }
        
        /// <summary>
        /// Default constructor. Initialize the default endpoint, URLProperties and requried URL properties.
        /// </summary>
        public PushMessage()
        {
            SendInitiator = 1;
            Endpoint = "https://www.exacttargetapis.com/push/v1/message";
            URLProperties = new string[0];
            RequiredURLProperties = new string[0];
        }

        /// <summary>
        /// Creates a push message.
        /// </summary>
        /// <param name="msg">PushMessage to be created.</param>
        /// <returns>Newly created PushMessage object.</returns>
        public static PushMessage CreatePushMessage(PushMessage msg)
        {
            return MobilePushReturn.CreatePushMessage(msg);
        }
        /// <summary>
        /// Gets all push messages associated with the account as an array.
        /// </summary>
        /// <param name="client">ETClient object <see cref="T:FuelSDK.ETClient"/></param>
        /// <returns>Array of PushMessage objects.</returns>
        public static PushMessage[] GetPushMessages(ETClient client)
        {
            return MobilePushReturn.GetPushMessages(client);
        }
        /// <summary>
        /// Gets a specific PushMessage identified by an Id.
        /// </summary>
        /// <param name="client">ETClient object <see cref="T:FuelSDK.ETClient"/></param>
        /// <param name="id">Id of the push message to get</param>
        /// <returns>PushMessage</returns>
        public static PushMessage GetPushMessage(ETClient client, string id)
        {
            return MobilePushReturn.GetPushMessage(client, id);
        }
        /// <summary>
        /// Update PushMessage
        /// </summary>
        /// <param name="msg">PushMessage to be updated</param>
        /// <returns>Updated PushMessage object</returns>
        public static PushMessage UpdatePushMessage(PushMessage msg)
        {
            return MobilePushReturn.UpdatePushMessage(msg);
        }
        /// <summary>
        /// Delete PushMessage
        /// </summary>
        /// <param name="client">ETClient object <see cref="T:FuelSDK.ETClient"/></param>
        /// <param name="id">PushMessage Id to be deleted</param>
        /// <returns>Returns true is successfully deleted</returns>
        public static bool DeletePushMessage(ETClient client, string id)
        {
            return MobilePushReturn.DeletePushMessage(client, id);
        }

        public static bool SendPushMessage(PushMessageSendObject sendObj)
        {
            return MobilePushReturn.SendPushMessage(sendObj);
        }



        public static bool SendPushMessageToList(PushMessageSendObject sendObj)
        {
            sendObj.Endpoint = "https://www.exacttargetapis.com/push/v1/messageList/{MessageId}/send";
            return MobilePushReturn.SendPushMessage(sendObj);
        }

        public static bool SendPushMessageToTaggedUsers(PushMessageSendObject sendObj)
        {
            sendObj.Endpoint = "https://www.exacttargetapis.com/push/v1/messageTag/{MessageId}/send";
            return MobilePushReturn.SendPushMessage(sendObj);
        }

        public static bool SendPushMessageToDevices(PushMessageSendObject sendObj)
        {
            sendObj.Endpoint = "https://www.exacttargetapis.com/push/v1/messageContact/{MessageId}/send";
            return MobilePushReturn.SendPushMessage(sendObj);
        }
    
    }
}