using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FuelSDK.MobilePush
{
    public enum PushMessageType
    {
        Outbound = 1,
        LocationEntry = 3,
        LocationExit = 4,
        Beacon = 5,
        Inbox = 8
    }
}
