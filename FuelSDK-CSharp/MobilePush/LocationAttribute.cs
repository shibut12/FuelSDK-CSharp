using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FuelSDK.MobilePush
{
    /// <summary>
    /// Represents attributes for the location
    /// </summary>
    public class LocationAttribute
    {
        /// <summary>
        /// Get or Set the name of the attribute
        /// </summary>
        public string Attribute { get; set; }
        /// <summary>
        /// Get or Set the value for the attribute
        /// </summary>
        public string Value { get; set; }
    }
}
