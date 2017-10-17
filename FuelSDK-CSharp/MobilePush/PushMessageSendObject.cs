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

        public string MessageId { get; set; }
        public bool Override { get; private set; }
        [JsonProperty(PropertyName = "messageText")]
        public string OverrideMessageText 
        { 
            get 
            {
                return messageText;
            }
            set
            {
                messageText = value;    //added
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
        //changed
        //public DateTime SendTime { get; set; }
        public string SendTime { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string BlackoutWindow { get; set; }
        [JsonProperty(PropertyName = "sound", NullValueHandling = NullValueHandling.Ignore)]
        public string SoundFileName { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Badge { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string OpenDirect { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Object CustomPayload { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public PushMessageKey[] CustomKeys { get; set; }



        public string[] InclusionTags { get; set; }
        public string[] ExclusionTags { get; set; }

        public string[] InclusionListIds { get; set; }
        public string[] ExclusionListIds { get; set; }

        public string[] DeviceTokens { get; set; }
        public string[] SubscriberKeys { get; set; }

        public PushMessageSendObject()
        {
            Override = false;
            Endpoint = "https://www.exacttargetapis.com/push/v1/messageApp/{MessageId}/send";
            URLProperties = new string[1] { "MessageId" };
            RequiredURLProperties = new string[1] { "MessageId" };
        }
    }
}
