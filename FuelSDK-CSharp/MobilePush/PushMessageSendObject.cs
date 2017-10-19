using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FuelSDK.MobilePush
{
    public class PushMessageSendObject : MobilePushBase
    {
        private string messageText;
        private string sendTime;
        /// <summary>
        /// Get or set Message Id
        /// </summary>
        public string MessageId { get; set; }
        /// <summary>
        /// Get override message flag. When the message text changed, this flag will set to true.
        /// </summary>
        public bool Override { get; private set; }
        /// <summary>
        /// Get or Set overwrite message text.
        /// </summary>
        [JsonProperty(PropertyName = "messageText")]
        public string OverrideMessageText 
        { 
            get 
            {
                return messageText;
            }
            set
            {
                messageText = value;  
                if (string.IsNullOrWhiteSpace(value))
                {
                    Override = false;
                }
                else
                {
                    Override = true;
                }
            }
        }
        /// <summary>
        /// Get or Set push message send date and time.
        /// </summary>
        public string SendTime {
            get
            {
                return sendTime;
            }
            set
            { 
                DateTime dt = new DateTime();
                
                var ret = DateTime.TryParse(value, out dt);
                if (ret)
                {
                    sendTime = dt.ToString("yyyy-MM-dd HH:mm");
                }
                else
                {
                    throw new FuelSDKException("Invalid date time value passed.");
                }
            }
        }
        /// <summary>
        /// Get or Set black out window.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string BlackoutWindow { get; set; }
        /// <summary>
        /// Get or Set sound file name to be played during alert message display.
        /// </summary>
        [JsonProperty(PropertyName = "sound", NullValueHandling = NullValueHandling.Ignore)]
        public string SoundFileName { get; set; }
        /// <summary>
        /// Get or Set badge in iOS devices.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Badge { get; set; }
        /// <summary>
        /// Get or Set Open Direct.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string OpenDirect { get; set; }
        /// <summary>
        /// Get or Set Custom definition in escaped JSON.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Object CustomPayload { get; set; }
        /// <summary>
        /// Get or Set an array of key/value pairs used as custom keys to be sent with the message request body
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public PushMessageKey[] CustomKeys { get; set; }
        /// <summary>
        /// Get or Set Tags used to identify contacts that will receive the message.
        /// </summary>
        public string[] InclusionTags { get; set; }
        /// <summary>
        /// Get or Set Tags used to identify contacts that will not receive the message.
        /// </summary>
        public string[] ExclusionTags { get; set; }
        /// <summary>
        /// Get or Set An array of one or more contact list ids to include in send.
        /// </summary>
        public string[] InclusionListIds { get; set; }
        /// <summary>
        /// Get or Set An array of one or more contact list ids to exclude in send.
        /// </summary>
        public string[] ExclusionListIds { get; set; }
        /// <summary>
        /// Get or Set Device tokens of the mobile devices that will receive the message. Required if subscriberKeys are not set.
        /// </summary>
        public string[] DeviceTokens { get; set; }
        /// <summary>
        /// Get or Set Subscriber keys of the mobile devices that will receive the message. Required if deviceTokens are not set.
        /// </summary>
        public string[] SubscriberKeys { get; set; }
        /// <summary>
        /// Default constructor. 
        /// </summary>
        public PushMessageSendObject()
        {
            Override = false;
            Endpoint = "https://www.exacttargetapis.com/push/v1/messageApp/{MessageId}/send";
            URLProperties = new string[1] { "MessageId" };
            RequiredURLProperties = new string[1] { "MessageId" };
        }
    }
}
