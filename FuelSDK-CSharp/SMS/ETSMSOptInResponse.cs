using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace FuelSDK.SMS
{
    public class ETSMSOptInResponse
    {
        public HttpStatusCode Code { get; set; }
        public string Error { get; set; }
        public string MessageID { get; set; }
        public string Message { get; set; }
        public string ErrorCode { get; set; }
        public string Documentation { get; set; }
        public string ValidationErrors { get; set; }
        public string ObjectErrors { get; set; }
        public string FieldErrors { get; set; }
    }
}
