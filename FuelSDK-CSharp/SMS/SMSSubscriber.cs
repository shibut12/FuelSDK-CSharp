using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FuelSDK.SMS
{
    /// <summary>
    /// SMSSubscriber class represent a single SMS/MobileConnect subscriber.
    /// </summary>
    public class SMSSubscriber
    {
        /// <summary>
        /// Subscriber mobile number as string.
        /// </summary>
        public string MobileNumber { get; set; }
        /// <summary>
        /// Subscriber's key.
        /// </summary>
        public string SubscriberKey { get; set; }

    }
}
