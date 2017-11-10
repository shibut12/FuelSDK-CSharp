using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FuelSDK.SMS
{
    /// <summary>
    /// Class that provides functionality to import SMS contacts.
    /// </summary>
    public class SMSContactsImporter : FuelObject
    {
        /// <summary>
        /// ID of the list to which the contacts should be imported to.
        /// </summary>
        public string ListId { get; set; }
        /// <summary>
        /// The short code.
        /// </summary>
        public string ShortCode { get; set; }
        /// <summary>
        /// The keyword.
        /// </summary>
        public string Keyword { get; set; }
        /// <summary>
        /// Flag to indicate if email should be sent to notify the status of the import.
        /// </summary>
        public bool SendEmailNotification { get; set; }
        /// <summary>
        /// Email address to which the status to be sent to.
        /// </summary>
        public string EmailAddress { get; set; }
        /// <summary>
        /// Import mapping type.
        /// Possible values: MapByHeaderRows, MapByOrdinal, MapManual
        /// </summary>
        public string ImportMappingType { get; set; }
        /// <summary>
        /// Name of the file to be imported.
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// File type.
        /// </summary>
        public string FileType { get; set; }
        /// <summary>
        /// Flag to indicate if the the first row in the file should be considered as header.
        /// </summary>
        public bool IsFirstRowHeader { get; set; }
        /// <summary>
        /// Array of field mapping.<see cref="FuelSDK.SMS.SMSContactsImportFieldMap"/>
        /// </summary>
        public SMSContactsImportFieldMap[] FieldMaps { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public SMSContactsImporter()
        {
            Endpoint = "https://www.exacttargetapis.com/sms/v1/contacts/queueImport/{ListId}";
            URLProperties = new string[1] { "ListId" };
            RequiredURLProperties = new string[1] { "ListId" };
        }
        /// <summary>
        /// Queues an contacts import job.
        /// </summary>
        /// <returns>TokenId as string. This token Id can be used to track the status of the import request.</returns>
        public string QueueImport()
        {
            return SMSReturn.ExecutePost(this);
        }
    }
}
