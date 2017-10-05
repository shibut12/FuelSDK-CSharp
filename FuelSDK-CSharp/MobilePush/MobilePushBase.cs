using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FuelSDK.MobilePush
{
    public class MobilePushBase
    {
        [JsonIgnore()]
        public string Endpoint { get; set; }
        [JsonIgnore()]
        public string[] URLProperties { get; set; }
        [JsonIgnore()]
        public string[] RequiredURLProperties { get; set; }
        [JsonIgnore()]
        public ETClient AuthStub { get; set; }
    }
}
