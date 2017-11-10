using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FuelSDK.SMS
{
    /// <summary>
    /// Class that represent the SMS contact import file field mapping.
    /// </summary>
    public class SMSContactsImportFieldMap
    {
        /// <summary>
        /// Destination column name.
        /// </summary>
        public string Destination { get; set; }
        /// <summary>
        /// Position of the column in the input file.
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// Source column/field name.
        /// </summary>
        public string Source { get; set; }
    }
}
