using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace FuelSDK.SMS
{
    public class SMSRefreshListResponse
    {
        public HttpStatusCode Code { get; set; }
        public string Error { get; set; }

        public string TokenId { get; set; }
        public string LastPublishDate { get; set; }
    }
}
