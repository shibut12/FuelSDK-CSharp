using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FuelSDK.MobilePush
{
    /// <summary>
    /// Represent Push message content type as an enumeration.
    /// </summary>
    public enum PushMessageContentType
    {
        Alert = 1,
        Inbox = 2,
        InboxAlert = 3
    }
}