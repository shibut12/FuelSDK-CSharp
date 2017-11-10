using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FuelSDK.SMS
{
    /// <summary>
    /// SMSImportSender class helps to imports and sends SMS to contacts.
    /// </summary>
    public class SMSImportSender : FuelObject
    {
        /// <summary>
        /// Encoded message Id to be sent.
        /// </summary>
        public string MessageId { get; set; }
        /// <summary>
        /// A valid keyword on the shortcode for the message to opt the numbers on to.
        /// </summary>
        public string Keyword { get; set; }
        /// <summary>
        /// If specified, email notifications will be sent on import and program completion.
        /// </summary>
        public string NotificationEmail { get; set; }
        /// <summary>
        /// Flag to indicate whether the override text should be used.
        /// </summary>
        public bool Override { get; set; }
        /// <summary>
        /// Text to override the existing message.
        /// </summary>
        public string OverrideText { get; set; }
        /// <summary>
        /// If true, duplicate messages may be sent.
        /// </summary>
        public bool IsDuplicationAllowed { get; set; }
        /// <summary>
        /// If specified true, the import definition and list created will be visible.
        /// </summary>
        public bool IsVisible { get; set; }
        /// <summary>
        /// List of Import Definitions to be created (currently limited to 1).
        /// </summary>
        public SMSImportDefinition[] ImportDefinition { get; set; }
        /// <summary>
        /// Default contructor.
        /// </summary>
        public SMSImportSender()
        {
            Endpoint = "https://www.exacttargetapis.com/sms/v1/automation/importSend";
            URLProperties = new string[0] { };
            RequiredURLProperties = new string[0] { };
        }
        /// <summary>
        /// Import and send SMS to contacts.
        /// </summary>
        /// <returns></returns>
        public string ImportAndSend()
        {
            return SMSReturn.ExecutePost(this);
        }

    }
}
