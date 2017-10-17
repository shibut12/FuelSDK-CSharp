using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace FuelSDK.SMS
{
    public class ETSMSKeywordResponse
    {
        public HttpStatusCode Code { get; set; }
        public string Message { get; set; }
        public string Error { get; set; }
        public string KeywordId { get; set; }
        public string Status { get; set; }
    }
}
