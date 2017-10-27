using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace FuelSDK.SMS
{
    /// <summary>
    /// QueueMOResponse class represent the response object returned by QueueMO request.
    /// </summary>
    public class QueueMOResponse
    {
        /// <summary>
        /// HTTP status code returned by QueueMO request.
        /// </summary>
        public HttpStatusCode Code { get; set; }
        /// <summary>
        /// Array of QueueMOResult returned by QueueMO request.
        /// </summary>
        public QueueMOResult[] Results { get; set; }
    }
}
