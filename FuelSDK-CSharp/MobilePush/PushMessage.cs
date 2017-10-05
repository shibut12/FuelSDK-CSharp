using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FuelSDK.MobilePush
{
    public class PushMessage : MobilePushBase
    {
        public string Id { get; set; }
        public PushMessageType MessageType { get; set; }
        public PushMessageContentType ContentType { get; set; }
        public string Name { get; set; }
        public PushMessageApplication Application { get; set; }
        public string Alert { get; set; }
        public string Sound { get; set; }
        public string Badge { get; set; }
        [JsonProperty(PropertyName = "content-available")]
        public int ContentAvailable { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string OpenDirect { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string[] Custom { get; set; }
        public int SendInitiator { get; private set; }
        public string StartDate { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string EndDate { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? MessagesPerPeriod { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? MinutesPerPeriod { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? NumberOfPeriods { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? PeriodType { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsRollingPeriod { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? MessageLimit { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool? TZBased { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string TZPastSendAction { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? ScheduleTZOffset { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool? ScheduledTZSupportsDst { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string[] InclusionLists { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string[] ExclusionLists { get; set; }
        public PushMessageStatus Status { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? PageId { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Url { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Subject { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string[] GeoFences { get; set; }
        
        public PushMessage()
        {
            SendInitiator = 1;
            Endpoint = "https://www.exacttargetapis.com/push/v1/message";
            URLProperties = new string[0];
            RequiredURLProperties = new string[0];
        }

        public static PushMessage CreatePushMessage(PushMessage msg)
        {
            return MobilePushReturn.CreatePushMessage(msg, RequestMethod.POST);
        }
    }
}
