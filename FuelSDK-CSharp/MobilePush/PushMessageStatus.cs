using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FuelSDK.MobilePush
{
    /// <summary>
    /// Represetns push message status as an enumeration
    /// </summary>
    public enum PushMessageStatus
    {
        Draft = 1,
        Active = 2,
        Inactive = 3,
        Deleted = 4
    }
}