using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

namespace FuelSDK.MobilePush
{
    /// <summary>
    /// MobilePushCustomKey class represents the custom key for mobile push
    /// </summary>
    public class MobilePushCustomKey : MobilePushBase
    {
        /// <summary>
        /// Get or Set the application ID of the custom key.
        /// </summary>
        /// <value>Application of the custom key</value>
        public string ApplicationId { get; set; }
        /// <summary>
        /// Get or Set all the keys.
        /// </summary>
        public string[] Keys { get; set; }
        /// <summary>
        /// Get or Set the key name of the custom key.
        /// </summary>
        /// <value>Key name of the custom key</value>
        public string KeyName { get; set; }
        /// <summary>
        /// Get or Set the description of the custom key.
        /// </summary>
        /// <value>Description of the custom key</value>
        public string Description { get; set; }

        /// <summary>
        /// Default constructor. Initialize the default endpoint, URLProperties and requried URL properties.
        /// </summary>
        public MobilePushCustomKey()
        {
            Endpoint = "https://www.exacttargetapis.com/push/v1/application/{ApplicationId}/key";
            URLProperties = new[] { "ApplicationId" };
            RequiredURLProperties = new[] { "ApplicationId" };
        }

        /// <summary>
        /// Deletes all custom keys.
        /// </summary>
        /// <returns>retruns true if successfull, false or exception otherwise.</returns>
        public bool DeleteCustomKeys()
        {
            if (ApplicationId == null || ApplicationId.Length == 0)
            {
                throw new ApplicationException("ApplicationId is either null or empty. Need to specify ApplicationId.");
            }
            return MobilePushReturn.DeleteCustomKeys(this, RequestMethod.DELETE);
        }

        /// <summary>
        /// Deletes one custom key associated with the key name.
        /// </summary>
        /// <returns>retruns true if successfull, false or exception otherwise.</returns>
        public bool DeleteCustomKey()
        {
            if (ApplicationId == null || ApplicationId.Length == 0)
            {
                throw new ApplicationException("ApplicationId is either null or empty. Need to specify ApplicationId.");
            }
            if (KeyName == null || KeyName.Length == 0)
            {
                throw new ApplicationException("KeyName is either null or empty. Need to specify KeyName.");
            }
            Endpoint = "https://www.exacttargetapis.com/push/v1/application/{ApplicationId}/key/{KeyName}";
            URLProperties = new[] { "ApplicationId", "KeyName" };
            RequiredURLProperties = new[] { "ApplicationId", "KeyName" };
            return MobilePushReturn.DeleteOneCustomKey(this, RequestMethod.DELETE);
        }

        public MobilePushCustomKey GetCustomKeys()
        {
            if (ApplicationId == null || ApplicationId.Length == 0)
            {
                throw new ApplicationException("ApplicationId is either null or empty. Need to specify ApplicationId.");
            }
            // code to get all Custom Keys & return response  with array of Custom Key objects
            return MobilePushReturn.GetCustomKeys(this, RequestMethod.GET);
        }

        /// <summary>
        /// Creates a custom key.
        /// </summary>
        /// <returns>retruns true if successfull, false or exception otherwise.</returns>
        public bool CreateCustomKey()
        {
            if (ApplicationId == null || ApplicationId.Length == 0)
            {
                throw new ApplicationException("ApplicationId is either null or empty. Need to specify ApplicationId.");
            }
            if (KeyName == null || KeyName.Length == 0)
            {
                throw new ApplicationException("KeyName is either null or empty. Need to specify KeyName.");
            }
            // code to update Custom Key & return response
            Endpoint = "https://www.exacttargetapis.com/push/v1/application/{ApplicationId}/key/{KeyName}";
            URLProperties = new[] { "ApplicationId", "KeyName" };
            RequiredURLProperties = new[] { "ApplicationId", "KeyName" };
            return MobilePushReturn.CreateCustomKey(this, RequestMethod.PUT);
        }

        /// <summary>
        /// Updates a custom key.
        /// </summary>
        /// <returns>retruns true if successfull, false or exception otherwise.</returns>
        public bool UpdateCustomKey()
        {
            if (ApplicationId == null || ApplicationId.Length == 0)
            {
                throw new ApplicationException("ApplicationId is either null or empty. Need to specify ApplicationId.");
            }
            if (KeyName == null || KeyName.Length == 0)
            {
                throw new ApplicationException("KeyName is either null or empty. Need to specify KeyName.");
            }
            Endpoint = "https://www.exacttargetapis.com/push/v1/application/{ApplicationId}/key/{KeyName}";
            URLProperties = new[] { "ApplicationId", "KeyName" };
            RequiredURLProperties = new[] { "ApplicationId", "KeyName" };
            return MobilePushReturn.UpdateCustomKey(this, RequestMethod.PUT);
        }

    }
}
