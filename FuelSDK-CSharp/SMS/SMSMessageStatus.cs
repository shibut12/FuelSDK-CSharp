using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FuelSDK.SMS
{
    public class SMSMessageStatus
    {
        /// <summary>
        /// The message text sent in the SMS message.
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// The total of mobile numbers included in the send request subtracting the number of unsubscribed recipients
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// Date when the MessageContact send was submitted, returned in CST
        /// </summary>
        public string CreateDate { get; set; }
        /// <summary>
        /// Date when the send completed, returned in CST
        /// </summary>
        public string CompleteDate { get; set; }
        /// <summary>
        /// Status of the message. Following are the possible values.
        ///         Finished
        ///         Error
        ///         New
        ///         Queuing
        ///         Started
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// Tracking information of each mobile number message sent to.
        /// <see cref="T:FuelSDK.SMS.SMSTracking"/>
        /// </summary>
        public SMSTracking Tracking { get; set; }
    }
}
