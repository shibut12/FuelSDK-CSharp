using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FuelSDK.SMS
{
    public class SMSRefreshList : FuelObject
    {
        public string ListId { get; set; }
        public SMSRefreshList()
        {
            Endpoint = "https://www.exacttargetapis.com/sms/v1/contacts/refreshList/{ListId}";
            URLProperties = new string[1] { "ListId" };
            RequiredURLProperties = new string[1] { "ListId" };
        }

        public SMSRefreshListResponse RefreshList()
        {
            SMSReturn smsreturn = new SMSReturn();
            return smsreturn.RefreshList(this, "POST");
        }
    }
}
