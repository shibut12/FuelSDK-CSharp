using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FuelSDK
{
    /// <summary>
    /// Class that represents the refresh list response
    /// </summary>
    public class RefreshListResponse
    {
        /// <summary>
        /// Token Id of the response. This can be used to check the status of the refresh request.
        /// </summary>
        public string TokenId { get; set; }
        /// <summary>
        /// Last publish date of the list.
        /// </summary>
        public DateTime LastPublishDate { get; set; }
    }
}
