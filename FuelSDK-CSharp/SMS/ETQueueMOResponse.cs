using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace FuelSDK.SMS
{
    public class ETQueueMOResponse
    {
        public HttpStatusCode Code { get; set; }
        public string Message { get; set; }
        public ETQueueMOResult[] Results { get; set; }
    }
}
