using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FuelSDK.MobilePush
{
    /// <summary>
    /// Represents a center point of the location circle
    /// </summary>
    public class LocationCenter
    {
        /// <summary>
        /// Get or Set the geographic latitude of the location center
        /// </summary>
        public double Latitude { get; set; }
        /// <summary>
        /// Get or Set the geographic longitude of the location center
        /// </summary>
        public double Longitude { get; set; }
    }
}
