using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FuelSDK.SMS
{
    /// <summary>
    /// Class that provides details about the window of time where messages should not be sent. 
    /// Messages initiated inside of this window will be queued and delivered once the window is open.
    /// </summary>
    public class SMSBlackoutWindow
    {
        /// <summary>
        /// The UTC offset of the blackout window start and end times. 
        /// UtcOffset is required in every REST call in order for the blackout window to be honored.
        /// </summary>
        [JsonIgnore]
        public float UtcOffset { get; set; }
        /// <summary>
        /// The start time of the blackout window, in the UTC offset specified. 
        /// To see if the SendTime is within the blackout window, convert the WindowStart and WindowEnd times to UTC and compare them to the SendTime
        /// </summary>
        [JsonIgnore]
        public DateTime WindowStart { get; set; }
        /// <summary>
        /// The end time of the blackout window, in the UTC offset specified. 
        /// To see if the SendTime is within the blackout window, convert the WindowStart and WindowEnd times to UTC and compare them to the SendTime
        /// </summary>
        [JsonIgnore]
        public DateTime WindowEnd { get; set; }
        /// <summary>
        /// String version of UtcOffset property
        /// </summary>
        [JsonProperty(PropertyName = "UtcOffset")]
        public string Offset
        {
            get
            {
                return UtcOffset.ToString();
            }
            private set { }
        }
        /// <summary>
        /// Formatted date time string of window start field.
        /// </summary>
        [JsonProperty(PropertyName = "WindowStart")]
        public string Start
        {
            get
            {
                return WindowStart.ToString("yyyy-MM-dd HH:mm");
            }
            private set { }
        }
        /// <summary>
        /// Formatted date time string of windows end field.
        /// </summary>
        [JsonProperty(PropertyName = "WindowEnd")]
        public string End
        {
            get
            {
                return WindowEnd.ToString("yyyy-MM-dd HH:mm");
            }
            private set { }
        }
    }
}
