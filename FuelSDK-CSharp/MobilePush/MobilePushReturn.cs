using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Diagnostics;

namespace FuelSDK.MobilePush
{
    internal class MobilePushReturn
    {

        internal static MobilePushLocation CreateLocation(MobilePushLocation obj)
        {
            var resp = ExecuteFuel(obj, obj.RequiredURLProperties, RequestMethod.POST.ToString(), true);
            if (resp.Code == HttpStatusCode.Created)
            {
                return JsonConvert.DeserializeObject<MobilePushLocation>(resp.Response);
            }
            else
            {
                var errors = GetErrorList(resp.Message);
                throw new FuelSDKException(errors);
            }

        }

        internal static MobilePushLocation GetLocation(MobilePushLocation obj)
        {
            var resp = ExecuteFuel(obj, obj.RequiredURLProperties, RequestMethod.GET.ToString(), false);
            if (resp.Code == HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<MobilePushLocation>(resp.Response);
            }
            else
            {
                var errors = GetErrorList(resp.Message);
                throw new FuelSDKException(errors);
            }
        }

        internal static MobilePushLocation[] GetLocations(ETClient client)
        {
            PushMessage obj = new PushMessage
            {
                AuthStub = client
            };
            var resp = ExecuteFuel(obj, obj.RequiredURLProperties, RequestMethod.GET.ToString(), false);
            if (resp.Code == HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<MobilePushLocation[]>(resp.Response);
            }
            else
            {
                var errors = GetErrorList(resp.Message);
                throw new FuelSDKException(errors);
            }

        }

        internal static bool DeleteLocation(MobilePushLocation obj)
        {
            var resp = ExecuteFuel(obj, obj.RequiredURLProperties, RequestMethod.DELETE.ToString(), false);
            if (resp.Code == HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                var errors = GetErrorList(resp.Message);
                throw new FuelSDKException(errors);
            }
        }

        internal static bool UpdateLocation(MobilePushLocation obj)
        {
            var resp = ExecuteFuel(obj, obj.RequiredURLProperties, RequestMethod.PUT.ToString(), true);
            if (resp.Code == HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                var errors = GetErrorList(resp.Message);
                throw new FuelSDKException(errors);
            }
        }

        internal static MobilePushCustomKey GetCustomKeys(MobilePushCustomKey obj, RequestMethod method)
        {
            var resp = ExecuteFuel(obj, obj.RequiredURLProperties, method.ToString(), false);
            if (resp.Code == HttpStatusCode.OK)
            {
                string r = "{\"keys\": " + resp.Response + "}";
                MobilePushCustomKey ret = JsonConvert.DeserializeObject<MobilePushCustomKey>(r);
                return ret;
            }
            else
            {
                var errors = GetErrorList(resp.Message);
                throw new FuelSDKException(errors);
            }
        }

        internal static bool DeleteCustomKeys(MobilePushCustomKey obj, RequestMethod method)
        {
            var resp = ExecuteFuel(obj, obj.RequiredURLProperties, method.ToString(), false);
            if (resp.Code == HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                var errors = GetErrorList(resp.Message);
                throw new FuelSDKException(errors);
            }
        }

        internal static bool DeleteOneCustomKey(MobilePushCustomKey obj, RequestMethod method)
        {
            var resp = ExecuteFuel(obj, obj.RequiredURLProperties, method.ToString(), false);
            if (resp.Code == HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                var errors = GetErrorList(resp.Message);
                throw new FuelSDKException(errors);
            }
        }

        internal static bool CreateCustomKey(MobilePushCustomKey obj, RequestMethod method)
        {
            var resp = ExecuteFuel(obj, obj.RequiredURLProperties, method.ToString(), false);
            if (resp.Code == HttpStatusCode.OK || resp.Code == HttpStatusCode.Created)
            {
                return true;
            }
            else
            {
                var errors = GetErrorList(resp.Message);
                throw new FuelSDKException(errors);
            }
        }

        internal static bool UpdateCustomKey(MobilePushCustomKey obj, RequestMethod method)
        {
            var resp = ExecuteFuel(obj, obj.RequiredURLProperties, method.ToString(), true);
            if (resp.Code == HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                var errors = GetErrorList(resp.Message);
                throw new FuelSDKException(errors);
            }
        }

        internal static PushMessage CreatePushMessage(PushMessage obj)
        {
            var resp = ExecuteFuel(obj, obj.RequiredURLProperties, RequestMethod.POST.ToString(), true);
            if (resp.Code == HttpStatusCode.Created)
            {
                return JsonConvert.DeserializeObject<PushMessage>(resp.Response);
            }
            else
            {
                var errors = GetErrorList(resp.Message);
                throw new FuelSDKException(errors);
            }

        }

        internal static PushMessage[] GetPushMessages(ETClient client)
        {
            PushMessage obj = new PushMessage
            {
                AuthStub = client
            };
            var resp = ExecuteFuel(obj, obj.RequiredURLProperties, RequestMethod.GET.ToString(), false);
            if (resp.Code == HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<PushMessage[]>(resp.Response);
            }
            else
            {
                var errors = GetErrorList(resp.Message);
                throw new FuelSDKException(errors);
            }

        }

        internal static PushMessage GetPushMessage(ETClient client, string id)
        {
            PushMessage obj = new PushMessage
            {
                Id = id,
                Endpoint = "https://www.exacttargetapis.com/push/v1/message/{Id}",
                URLProperties = new string[1] { "Id" },
                RequiredURLProperties = new string[1] { "Id" },
                AuthStub = client
            };
            var resp = ExecuteFuel(obj, obj.RequiredURLProperties, RequestMethod.GET.ToString(), false);
            if (resp.Code == HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<PushMessage>(resp.Response);
            }
            else
            {
                var errors = GetErrorList(resp.Message);
                throw new FuelSDKException(errors);
            }

        }

        internal static PushMessage UpdatePushMessage(PushMessage obj)
        {

            obj.Endpoint = "https://www.exacttargetapis.com/push/v1/message/{Id}";
            obj.URLProperties = new string[1] { "Id" };
            obj.RequiredURLProperties = new string[1] { "Id" };

            var resp = ExecuteFuel(obj, obj.RequiredURLProperties, RequestMethod.PUT.ToString(), true);
            if (resp.Code == HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<PushMessage>(resp.Response);
            }
            else
            {
                var errors = GetErrorList(resp.Message);
                throw new FuelSDKException(errors);
            }
        }

        internal static bool DeletePushMessage(ETClient client, string id)
        {
            PushMessage obj = new PushMessage
            {
                Id = id,
                Endpoint = "https://www.exacttargetapis.com/push/v1/message/{Id}",
                URLProperties = new string[1] { "Id" },
                RequiredURLProperties = new string[1] { "Id" },
                AuthStub = client
            };
            var resp = ExecuteFuel(obj, obj.RequiredURLProperties, RequestMethod.DELETE.ToString(), false);
            if (resp.Code == HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                var errors = GetErrorList(resp.Message);
                throw new FuelSDKException(errors);
            }
        }

        internal static bool SendPushMessage(PushMessageSendObject obj)
        {
            var resp = ExecuteFuel(obj, obj.RequiredURLProperties, RequestMethod.POST.ToString(), true);    //changed from false to true
            Debug.WriteLine("Rest Out = "+resp.Message);
            if (resp.Code == HttpStatusCode.Accepted)
            {
                return true;
            }
            else
            {
                var errors = GetErrorList(resp.Message);
                throw new FuelSDKException(errors);
            }
        }

        internal static RefreshListResponse RefreshList(ContactList obj)
        {
            var resp = ExecuteFuel(obj, obj.RequiredURLProperties, RequestMethod.POST.ToString(), false);
            if (resp.Code == HttpStatusCode.Accepted)
            {
                return JsonConvert.DeserializeObject<RefreshListResponse>(resp.Response);
            }
            else
            {
                var errors = GetErrorList(resp.Message);
                throw new FuelSDKException(errors);
            }
        }

        internal static RefreshListResponse GetRefreshListStatus(ContactList obj)
        {
            var resp = ExecuteFuel(obj, obj.RequiredURLProperties, RequestMethod.GET.ToString(), false);
            if (resp.Code == HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<RefreshListResponse>(resp.Response);
            }
            else
            {
                var errors = GetErrorList(resp.Message);
                throw new FuelSDKException(errors);
            }
        }

        private static PushMessageResponse ExecuteFuel(MobilePushBase pushObj, string[] required, string method, bool postValue)
        {
            if (pushObj == null)
                throw new ArgumentNullException("PushMessage object is null");
            pushObj.AuthStub.RefreshToken();

            object propValue;
            string propValueAsString;
            var completeURL = pushObj.Endpoint;
            if (required != null)
            {
                foreach (string urlProp in required)
                {
                    var match = false;
                    foreach (var prop in pushObj.GetType().GetProperties())
                    {
                        if (prop.Name == "UniqueID")
                            continue;
                        if (pushObj.URLProperties.Contains(prop.Name) && (propValue = prop.GetValue(pushObj, null)) != null)
                            if ((propValueAsString = propValue.ToString().Trim()).Length > 0 && propValueAsString != "0")
                                match = true;
                    }
                    if (!match)
                        throw new Exception("Unable to process request due to missing required property: " + urlProp);
                }
            }
            foreach (var prop in pushObj.GetType().GetProperties())
            {
                if (prop.Name == "UniqueID")
                {
                    continue;
                }
                if ((pushObj.URLProperties.Contains(prop.Name) && (propValue = prop.GetValue(pushObj, null)) != null) &&
                    ((propValueAsString = propValue.ToString().Trim()).Length > 0 && propValueAsString != "0"))
                {
                    //need to convert DateTime object if it is not string
                    //if (prop.PropertyType == typeof(DateTime))
                    //    propValueAsString = ((DateTime)prop.GetValue(pushObj, null)).ToString("yyyy-MM-dd HH:mm");
                    completeURL = completeURL.Replace("{" + prop.Name + "}", propValueAsString);
                }
            }

            // Clean up not required URL parameters
            if (pushObj.URLProperties != null)
            {
                foreach (string urlProp in pushObj.URLProperties)
                {
                    completeURL = completeURL.Replace("{" + urlProp + "}", string.Empty);
                }
            }
            completeURL += "?access_token=" + pushObj.AuthStub.AuthToken;
            //this code may be needed.. leaving commented to revisit later
            //if (pushObj.Page != 0)
            //    completeURL += "&page=" + pushObj.Page.ToString();

            var request = (HttpWebRequest)WebRequest.Create(completeURL.Trim());
            request.Method = method;
            request.ContentType = "application/json";
            request.UserAgent = ETClient.SDKVersion;

            if (postValue)
                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                    streamWriter.Write(JsonConvert.SerializeObject(pushObj));

            // Get the response
            try
            {
                using (var response = (HttpWebResponse)request.GetResponse())
                using (var dataStream = response.GetResponseStream())
                using (var reader = new StreamReader(dataStream))
                {
                    PushMessageResponse resp = new PushMessageResponse
                    {
                        Code = response.StatusCode,
                        Message = response.ToString(),
                        Response = reader.ReadToEnd()
                    };
                    return resp;
                }
            }
            catch (WebException we)
            {
                using (var stream = we.Response.GetResponseStream())
                using (var reader = new StreamReader(stream))
                {
                    PushMessageResponse resp = new PushMessageResponse
                    {
                        Code = ((HttpWebResponse)we.Response).StatusCode,
                        Message = reader.ReadToEnd(),
                        Response = string.Empty
                    };
                    return resp;
                }
            }
        }

        private static string[] GetErrorList(string message)
        {
            string[] errorList = new string[0];
            var x = JObject.Parse(message);
            if (x["errors"] != null)
            {
                var resultArray = x.Children<JProperty>().FirstOrDefault(o => o.Name == "errors").Value;
                errorList = resultArray.Select(e => e.ToString()).ToArray();
            }
            return errorList;
        }
    }
}
