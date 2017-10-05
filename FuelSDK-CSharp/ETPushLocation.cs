using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

namespace FuelSDK
{
    public class ETPushLocation : FuelObject
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
        public string LocationId { get; set; }

        public ETPushLocation()
        {
            Endpoint = "https://www.exacttargetapis.com/push/v1/location";
            URLProperties = new string[0];
            RequiredURLProperties = new string[0];
        }

        public ETPushLocation(JToken obj)
        {
        }

        public void CreateLocation()
        {
            if (Name == null || Name.Length == 0)
            {
                throw new ApplicationException("Name is either null or empty. Need to specify Name.");
            }
            // code to create location & return LocationID 
        }

        public void DeleteLocation()
        {
            if (LocationId == null || LocationId.Length == 0)
            {
                throw new ApplicationException("LocationId is either null or empty. Need to specify LocationId.");
            }
            Endpoint = "https://www.exacttargetapis.com/push/v1/location/{LocationId}";
            URLProperties = new[] { "LocationId" };
            RequiredURLProperties = new[] { "LocationId" };
            // code to delete location & return response 
        }

        public void UpdateLocation()
        {
            if (LocationId == null || LocationId.Length == 0)
            {
                throw new ApplicationException("LocationId is either null or empty. Need to specify LocationId.");
            }
            if (Name == null || Name.Length == 0)
            {
                throw new ApplicationException("Name is either null or empty. Need to specify Name.");
            }
            Endpoint = "https://www.exacttargetapis.com/push/v1/location/{LocationId}";
            URLProperties = new[] { "LocationId" };
            RequiredURLProperties = new[] { "LocationId" };
            // code to update location & return response 
        }

        public void GetSpecificLocation()
        {
            if (LocationId == null || LocationId.Length == 0)
            {
                throw new ApplicationException("LocationId is either null or empty. Need to specify LocationId.");
            }
            Endpoint = "https://www.exacttargetapis.com/push/v1/location/{LocationId}";
            URLProperties = new[] { "LocationId" };
            RequiredURLProperties = new[] { "LocationId" };
            // code to get specific location & return response with Location object 
        }

        public void GetLocations()
        {
            // code to get all locations & return response with array of Location objects
        }

    }
    
    class LocationCenter
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

    class LocationAttribute
    {
        public string Attribute { get; set; }
        public string Value { get; set; }
    }
}
