using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

namespace FuelSDK
{
    public class ETPushCustomKey : FuelObject
    {
        public string ApplicationId { get; set; }
        public CustomKey[] Keys { get; set; }

        public ETPushCustomKey()
        {
            Endpoint = "https://www.exacttargetapis.com/push/v1/application/{ApplicationId}/key";
            URLProperties = new[] { "ApplicationId" };
            RequiredURLProperties = new[] { "ApplicationId" };
        }

        public ETPushCustomKey(JToken obj)
        {
        }

        public void DeleteCustomKey()
        {
            if (ApplicationId == null || ApplicationId.Length == 0)
            {
                throw new ApplicationException("ApplicationId is either null or empty. Need to specify ApplicationId.");
            }
            // code to delete Custom Key & return response
        }

        public void GetCustomKey()
        {
            if (ApplicationId == null || ApplicationId.Length == 0)
            {
                throw new ApplicationException("ApplicationId is either null or empty. Need to specify ApplicationId.");
            }
            // code to get all Custom Keys & return response  with array of Custom Key objects
        }

        public void UpdateCustomKey()
        {
            if (ApplicationId == null || ApplicationId.Length == 0)
            {
                throw new ApplicationException("ApplicationId is either null or empty. Need to specify ApplicationId.");
            }
            // code to update Custom Key & return response
        }

    }

    class CustomKey
    {
        public string Key { get; set; }
        public string Description { get; set; }
    }
}
