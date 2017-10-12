using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FuelSDK.MobilePush
{
    /// <summary>
    /// Class that represents a contact list object
    /// </summary>
    public class ContactList : MobilePushBase
    {
        /// <summary>
        /// The ID of the list in MobileConnect
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// The unique ID returned when using the RefreshList operation
        /// </summary>
        public string TokenId { get; set; }
        /// <summary>
        /// Default constructor
        /// </summary>
        public ContactList()
        {
            Endpoint = "https://www.exacttargetapis.com/push/v1/contacts/refreshList/{Id}";
            URLProperties = new string[1] { "Id" };
            RequiredURLProperties = new string[1] { "Id" };
        }
        /// <summary>
        /// Refresh a list.
        /// </summary>
        /// <param name="listid">Id of the list to be refreshed</param>
        /// <returns>Refresh list response <see cref="T:FuelSDK.MobilePush.RefreshListResponse"/></returns>
        public RefreshListResponse RefreshList(string listid)
        {
            this.Id = listid;
            return MobilePushReturn.RefreshList(this);
        }
        /// <summary>
        /// Get status of the previous refresh list request.
        /// </summary>
        /// <param name="listid">Id of the list requested previously to refresh</param>
        /// <param name="tokenid">Token id returned as a response for a previous list refresh request.</param>
        /// <returns>Refresh list response <see cref="T:FuelSDK.MobilePush.RefreshListResponse"/></returns>
        public RefreshListResponse GetRefreshListStatus(string listid, string tokenid)
        {
            Endpoint = "https://www.exacttargetapis.com/push/v1/contacts/refreshList/{Id}/status/{TokenId}";
            URLProperties = new string[2] { "Id", "TokenId" };
            RequiredURLProperties = new string[2] { "Id", "TokenId" };
            Id = listid;
            TokenId = tokenid;
            return MobilePushReturn.GetRefreshListStatus(this);
        }
    }
}
