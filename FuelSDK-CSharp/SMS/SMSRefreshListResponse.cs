using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace FuelSDK.SMS
{
    /// <summary>
    /// Represents SMS message refresh list response class
    /// </summary>
    public class SMSRefreshListResponse
    {
        /// <summary>
        /// Get or Set the Http status code
        /// </summary>
        public HttpStatusCode Code { get; set; }
        /// <summary>
        /// Get or set the error message.
        /// </summary>
        public string Error { get; set; }

        /// <summary>
        /// Get or set the token id.
        /// </summary>
        public string TokenId { get; set; }
        /// <summary>
        /// Get or set the last publish date.
        /// </summary>
        public string LastPublishDate { get; set; }
    }
}
