using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FuelSDK.MobilePush
{
    /// <summary>
    /// Base class for MobilePush resource objects.
    /// </summary>
    public class MobilePushBase
    {
        /// <summary>
        /// Get or Set the end point URL 
        /// </summary>
        /// <value>End point uRL</value>
        [JsonIgnore()]
        public string Endpoint { get; set; }
        /// <summary>
        /// Get or Set the array of property names to be set in as part of the URL. 
        /// This needs to match the properties of the object.
        /// </summary>
        /// <value>Property name array</value>
        [JsonIgnore()]
        public string[] URLProperties { get; set; }
        /// <summary>
        /// Get or Set the array of required property names in the URL properties.
        /// </summary>
        /// <value>Required property name array</value>
        [JsonIgnore()]
        public string[] RequiredURLProperties { get; set; }
        /// <summary>
        /// Get or Set authentication stub. <see cref="T:FuelSDK.ETClient"/>
        /// </summary>
        /// <value>ETClient object</value>
        [JsonIgnore()]
        public ETClient AuthStub { get; set; }
    }
}
