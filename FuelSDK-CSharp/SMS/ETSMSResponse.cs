using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace FuelSDK.SMS
{
    class ETSMSResponse
    {
        public HttpStatusCode Code { get; set; }
        public string Message { get; set; }
        public string Response { get; set; }
    }
}
