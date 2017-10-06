using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace FuelSDK.MobilePush
{
    public class MobilePushLocation : MobilePushBase
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string ProximityUuid { get; set; }
        public int Radius { get; set; }
        public int LocationType { get; set; }
        public int Major { get; set; }
        public int Minor { get; set; }
        public LocationCenter Center  { get; set; }
        public LocationAttribute[] Attributes  { get; set; }
        [JsonProperty(PropertyName = "id")]
        public string LocationId { get; set; }

        public MobilePushLocation()
        {
            Endpoint = "https://www.exacttargetapis.com/push/v1/location";
            URLProperties = new string[0];
            RequiredURLProperties = new string[0];
        }

        public MobilePushLocation(JToken obj)
        {
        }

        public MobilePushLocation CreateLocation()
        {
            if (Name == null || Name.Length == 0)
            {
                throw new ApplicationException("Name is either null or empty. Need to specify Name.");
            }
            // code to create location & return LocationID 
            return MobilePushReturn.CreateLocation(this, RequestMethod.POST);
        }

        public bool DeleteLocation()
        {
            if (LocationId == null || LocationId.Length == 0)
            {
                throw new ApplicationException("LocationId is either null or empty. Need to specify LocationId.");
            }
            Endpoint = "https://www.exacttargetapis.com/push/v1/location/{LocationId}";
            URLProperties = new[] { "LocationId" };
            RequiredURLProperties = new[] { "LocationId" };
            // code to delete location & return response 
            return MobilePushReturn.DeleteLocation(this, RequestMethod.DELETE);
        }

        public bool UpdateLocation()
        {
            if (LocationId == null || LocationId.Length == 0)
            {
                throw new ApplicationException("LocationId is either null or empty. Need to specify LocationId.");
            }
            if (Name == null || Name.Length == 0)
            {
                throw new ApplicationException("Name is either null or empty. Need to specify Name.");
            }
            if (Radius == null)
            {
                throw new ApplicationException("Radius is required.");
            }
            if (Center == null)
            {
                throw new ApplicationException("Center is required.");
            }
            Endpoint = "https://www.exacttargetapis.com/push/v1/location/{LocationId}";
            URLProperties = new[] { "LocationId" };
            RequiredURLProperties = new[] { "LocationId" };
            // code to update location & return response 
            return MobilePushReturn.UpdateLocation(this, RequestMethod.PUT);
        }

        public MobilePushLocation GetSpecificLocation()
        {
            if (LocationId == null || LocationId.Length == 0)
            {
                throw new ApplicationException("LocationId is either null or empty. Need to specify LocationId.");
            }
            Endpoint = "https://www.exacttargetapis.com/push/v1/location/{LocationId}";
            URLProperties = new[] { "LocationId" };
            RequiredURLProperties = new[] { "LocationId" };
            // code to get specific location & return response with Location object 
            return MobilePushReturn.GetLocation(this, RequestMethod.GET);
        }

        public void GetLocations()
        {
            // code to get all locations & return response with array of Location objects
        }

    }
    
    public class LocationCenter
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

    public class LocationAttribute
    {
        public string Attribute { get; set; }
        public string Value { get; set; }
    }
}
