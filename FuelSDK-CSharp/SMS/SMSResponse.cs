using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace FuelSDK.SMS
{
    /// <summary>
    /// Class that represent the response object returned by executing SMS related request.
    /// </summary>
    internal class SMSResponse
    {
        /// <summary>
        /// HTTP status code of the response.
        /// </summary>
        public HttpStatusCode Code { get; set; }
        /// <summary>
        /// Error message as string.
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Actual json string returned as the response.
        /// </summary>
        public string Response { get; set; }
    }
}

