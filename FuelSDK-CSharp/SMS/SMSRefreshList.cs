using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FuelSDK.SMS
{
    /// <summary>
    /// SMSRefreshList class represents SMS refresh list object
    /// </summary>
    public class SMSRefreshList : FuelObject
    {
        /// <summary>
        /// Get or Set the filtered list ID
        /// </summary>
        public string ListId { get; set; }
        /// <summary>
        /// Get or Set the token ID to get the status
        /// </summary>
        public string TokenId { get; set; }

        /// <summary>
        /// Default constructor. Initialize the default endpoint, URLProperties and requried URL properties.
        /// </summary>
        public SMSRefreshList()
        {
            Endpoint = "https://www.exacttargetapis.com/sms/v1/contacts/refreshList/{ListId}";
            URLProperties = new string[1] { "ListId" };
            RequiredURLProperties = new string[1] { "ListId" };
        }

        /// <summary>
        /// Refreshes a list.
        /// </summary>
        /// <returns>SMSRefreshListResponse object <see cref="T:namespace FuelSDK.SMS.SMSRefreshListResponse"/></returns>
        public SMSRefreshListResponse RefreshList()
        {
            SMSReturn smsreturn = new SMSReturn();
            return smsreturn.RefreshList(this, "POST");
        }

        /// <summary>
        /// Retrieves the refresh list status.
        /// </summary>
        /// <returns>SMSRefreshListResponse object <see cref="T:namespace FuelSDK.SMS.SMSRefreshListResponse"/></returns>
        public SMSRefreshListResponse GetRefreshListStatus()
        {
            Endpoint = "https://www.exacttargetapis.com/sms/v1/contacts/refreshList/{ListId}/status/{TokenId}";
            URLProperties = new string[2] { "ListId", "TokenId" };
            RequiredURLProperties = new string[2] { "ListId", "TokenId" };

            SMSReturn smsreturn = new SMSReturn();
            return smsreturn.GetRefreshListStatus(this, "GET");
        }
    }
}
