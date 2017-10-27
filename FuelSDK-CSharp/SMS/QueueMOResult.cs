using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace FuelSDK.SMS
{
    /// <summary>
    /// QueueMOResult class represent the result object returned by QueueMO request.
    /// </summary>
    public class QueueMOResult
    {
        /// <summary>
        /// String identifier which identifies the QueueMO request.
        /// </summary>
        public string Identifier { get; set; }
        /// <summary>
        /// Mobile number as string for which the QueueMO request was made.
        /// </summary>
        public string MobileNumber { get; set; }
        /// <summary>
        /// Subscribers as an array for which the QueueMO request was made.
        /// </summary>
        public SMSSubscriber[] Subscribers { get; set; }
        /// <summary>
        /// Result as string. Set to OK if the request was successful.
        /// </summary>
        public string Result { get; set; } 
    }
}
