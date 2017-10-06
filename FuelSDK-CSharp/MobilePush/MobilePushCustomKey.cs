using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

namespace FuelSDK.MobilePush
{
    public class MobilePushCustomKey : MobilePushBase
    {
        public string ApplicationId { get; set; }
        //public CustomKey[] Keys { get; set; }
        public string[] Keys { get; set; }
        public string KeyName { get; set; }
        public string Description { get; set; }

        public MobilePushCustomKey()
        {
            Endpoint = "https://www.exacttargetapis.com/push/v1/application/{ApplicationId}/key";
            URLProperties = new[] { "ApplicationId" };
            RequiredURLProperties = new[] { "ApplicationId" };
        }

        public MobilePushCustomKey(JToken obj)
        {
        }

        public bool DeleteCustomKeys()
        {
            if (ApplicationId == null || ApplicationId.Length == 0)
            {
                throw new ApplicationException("ApplicationId is either null or empty. Need to specify ApplicationId.");
            }
            // code to delete Custom Key & return response
            return MobilePushReturn.DeleteCustomKeys(this, RequestMethod.DELETE);
        }

        public bool DeleteOneCustomKey()
        {
            if (ApplicationId == null || ApplicationId.Length == 0)
            {
                throw new ApplicationException("ApplicationId is either null or empty. Need to specify ApplicationId.");
            }
            if (KeyName == null || KeyName.Length == 0)
            {
                throw new ApplicationException("KeyName is either null or empty. Need to specify KeyName.");
            }
            // code to delete Custom Key & return response
            Endpoint = "https://www.exacttargetapis.com/push/v1/application/{ApplicationId}/key/{KeyName}";
            URLProperties = new[] { "ApplicationId", "KeyName" };
            RequiredURLProperties = new[] { "ApplicationId", "KeyName" };
            return MobilePushReturn.DeleteOneCustomKey(this, RequestMethod.DELETE);
        }

        public MobilePushCustomKey GetCustomKey()
        {
            if (ApplicationId == null || ApplicationId.Length == 0)
            {
                throw new ApplicationException("ApplicationId is either null or empty. Need to specify ApplicationId.");
            }
            // code to get all Custom Keys & return response  with array of Custom Key objects
            return MobilePushReturn.GetCustomKeys(this, RequestMethod.GET);
        }

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

    public class CustomKey
    {
        public string Key { get; set; }
        public string Description { get; set; }
    }
}
