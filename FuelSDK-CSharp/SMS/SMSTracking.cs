using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FuelSDK.SMS
{
    /// <summary>
    /// Class represent SMS tracking information.
    /// </summary>
    public class SMSTracking
    {
        /// <summary>
        /// Mobile number for which tracking information provided.
        /// </summary>
        public string MobileNumber { get; set; }
        /// <summary>
        /// Status code of the SMS message sent to the mobile number.
        /// </summary>
        public string StatusCode { get; set; }
        /// <summary>
        /// Status message.
        /// </summary>
        public string Message { get; set; }
    }
}
