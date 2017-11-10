using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FuelSDK.SMS
{
    /// <summary>
    /// Class that represents a SMS Import Definition.
    /// </summary>
    public class SMSImportDefinition
    {
        /// <summary>
        /// Import type, FILE or DATA_EXTENSION
        /// </summary>
        public string ImportType { get; set; }
        /// <summary>
        /// Import mapping type.
        /// Possible values: InferFromColumnHeadings, MapManual
        /// </summary>
        public string ImportMappingType { get; set; }
        /// <summary>
        /// Name of the file to be imported.
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// If the import type is DATA_EXTENSION, dataextensionname field is used to identify the DE to be used.
        /// </summary>
        public string DataExtensionName { get; set; }
        /// <summary>
        /// Flag to indicate if the the first row in the file should be considered as header.
        /// </summary>
        public bool IsFirstRowHeader { get; set; }
        /// <summary>
        /// Array of field mapping.<see cref="FuelSDK.SMS.SMSContactsImportFieldMap"/>
        /// </summary>
        public SMSContactsImportFieldMap[] FieldMaps { get; set; }
    }
}
