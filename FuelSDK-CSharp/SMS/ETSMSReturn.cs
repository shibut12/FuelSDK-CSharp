using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;

namespace FuelSDK.SMS
{
    public class ETSMSReturn
    {

        internal ETQueueMOResponse QueueMO(FuelObject obj)
        {
            ETSMSResponse resp = ExecuteFuel(obj, obj.RequiredURLProperties, "POST", true);
            var result = new ETQueueMOResponse();
            result.Code = resp.Code;
            
            var emoResp = new List<ETQueueMOResult>();
            if (!string.IsNullOrEmpty(resp.Response))
            {
                result.Message = resp.Code.ToString();
                var x = JObject.Parse(resp.Response);
                if (x["results"] != null)
                {
                    var resultArray = x.Children<JProperty>().FirstOrDefault(o => o.Name == "results").Value;
                    foreach (var item in resultArray)
                    {
                        emoResp.Add(item.ToObject<ETQueueMOResult>());
                    }
                }
            }
            else 
            {
                var x = JObject.Parse(resp.Message);
                if (x["errors"] != null)
                {
                    var resultArray = x.Children<JProperty>().FirstOrDefault(o => o.Name == "errors").Value;
                    result.Message = resultArray[0].ToString();
                }

            }
            result.Results = emoResp.ToArray();
            return result;

        }

        internal ETSMSKeywordResponse PerformKeywordOperation(FuelObject obj, string method)
        {
            ETSMSResponse resp = ExecuteFuel(obj, obj.RequiredURLProperties, method, true);
            ETSMSKeywordResponse result = new ETSMSKeywordResponse();
            if (!string.IsNullOrEmpty(resp.Response))
            {
                result.Code = resp.Code;
                var x = JObject.Parse(resp.Response);
                if (x["keywordId"] != null)
                {
                    result.KeywordId = x["keywordId"].ToString();
                }
                else if (x["status"] != null)
                {
                    result.Status = x["status"].ToString();
                }

            }
            else 
            {
                result.Code = resp.Code;
                var x = JObject.Parse(resp.Message);
                if (x["errors"] != null)
                {
                    result.Error = x["errors"].ToString();
                }
            }
            return result;
        }

        internal ETSMSOptInResponse OptInMessage(FuelObject obj, string method)
        {
            ETSMSResponse resp = ExecuteFuel(obj, obj.RequiredURLProperties, method, true);
            ETSMSOptInResponse result = new ETSMSOptInResponse();
            if (!string.IsNullOrEmpty(resp.Response))
            {
                result.Code = resp.Code;
                var x = JObject.Parse(resp.Response);
                if (x["messageID"] != null)
                {
                    result.MessageID = x["messageID"].ToString();
                }

            }
            else
            {
                result.Code = resp.Code;
                var x = JObject.Parse(resp.Message);
                if (x["message"] != null)
                {
                    result.Message = x["message"].ToString();
                }
                if (x["errors"] != null)
                {
                    result.Error = x["errors"].ToString();
                }
                if (x["errorcode"] != null)
                {
                    result.ErrorCode = x["errorcode"].ToString();
                }
                if (x["documentation"] != null)
                {
                    result.Documentation = x["documentation"].ToString();
                }
                if (x["validationErrors"] != null)
                {
                    result.ValidationErrors = x["validationErrors"].ToString();
                }
                if (x["objectErrors"] != null)
                {
                    result.ObjectErrors = x["objectErrors"].ToString();
                }
                if (x["fieldErrors"] != null)
                {
                    result.FieldErrors = x["fieldErrors"].ToString();
                }
            }
            return result;
        }

        private ETSMSResponse ExecuteFuel(FuelObject obj, string[] required, string method, bool postValue)
        {
            if (obj == null)
                throw new ArgumentNullException("obj");
            obj.AuthStub.RefreshToken();

            object propValue;
            string propValueAsString;
            var completeURL = obj.Endpoint;
            if (required != null)
                foreach (string urlProp in required)
                {
                    var match = false;
                    foreach (var prop in obj.GetType().GetProperties())
                    {
                        if (prop.Name == "UniqueID")
                            continue;
                        if (obj.URLProperties.Contains(prop.Name) && (propValue = prop.GetValue(obj, null)) != null)
                            if ((propValueAsString = propValue.ToString().Trim()).Length > 0 && propValueAsString != "0")
                                match = true;
                    }
                    if (!match)
                        throw new Exception("Unable to process request due to missing required property: " + urlProp);
                }
            foreach (var prop in obj.GetType().GetProperties())
            {
                if (prop.Name == "UniqueID")
                    continue;
                if (obj.URLProperties.Contains(prop.Name) && (propValue = prop.GetValue(obj, null)) != null)
                    if ((propValueAsString = propValue.ToString().Trim()).Length > 0 && propValueAsString != "0")
                        completeURL = completeURL.Replace("{" + prop.Name + "}", propValueAsString);
            }

            // Clean up not required URL parameters
            if (obj.URLProperties != null)
                foreach (string urlProp in obj.URLProperties)
                    completeURL = completeURL.Replace("{" + urlProp + "}", string.Empty);

            completeURL += "?access_token=" + obj.AuthStub.AuthToken;
            if (obj.Page != 0)
                completeURL += "&page=" + obj.Page.ToString();

            var request = (HttpWebRequest)WebRequest.Create(completeURL.Trim());
            request.Method = method;
            request.ContentType = "application/json";
            request.UserAgent = ETClient.SDKVersion;

            if (postValue)
                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                    streamWriter.Write(JsonConvert.SerializeObject(obj));

            // Get the response
            try
            {
                using (var response = (HttpWebResponse)request.GetResponse())
                using (var dataStream = response.GetResponseStream())
                using (var reader = new StreamReader(dataStream))
                {
                    ETSMSResponse resp = new ETSMSResponse
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
                    ETSMSResponse resp = new ETSMSResponse
                    {
                        Code = ((HttpWebResponse)we.Response).StatusCode,
                        Message = reader.ReadToEnd(),
                        Response = string.Empty
                    };
                    return resp;
                }
            }
        }
    }
}
