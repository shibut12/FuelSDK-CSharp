using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace FuelSDK.MobilePush
{
    /// <summary>
    /// Represents a push message response class
    /// </summary>
    public class PushMessageResponse
    {
        /// <summary>
        /// Get or Set the Http status code
        /// </summary>
        public HttpStatusCode Code { get; set; }
        /// <summary>
        /// Get or set the response message.
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Get or Set the response string
        /// </summary>
        public string Response { get; set; }
    }
}
