using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FuelSDK
{
    public class ETTriggeredSendSummary : TriggeredSendSummary
    {
        /// <summary>
        /// Get this instance of ETTriggeredSendSummary.
        /// </summary>
        /// <returns>The <see cref="T:FuelSDK.GetReturn"/> object..</returns>
        public GetReturn Get() { var r = new GetReturn(this); LastRequestID = r.RequestID; return r; }
        /// <summary>
        /// Info of this instance, ETTriggeredSendSummary.
        /// </summary>
        /// <returns>The <see cref="T:FuelSDK.InfoReturn"/> object..</returns>
        public InfoReturn Info() { return new InfoReturn(this); }
    }
}
