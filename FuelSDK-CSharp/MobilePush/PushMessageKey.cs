using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FuelSDK.MobilePush
{
    /// <summary>
    /// Presents a push message key class
    /// </summary>
    public class PushMessageKey
    {
        /// <summary>
        /// Get or Set the key name
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// Get or set the value of the key
        /// </summary>
        public string Value { get; set; }
    }
}