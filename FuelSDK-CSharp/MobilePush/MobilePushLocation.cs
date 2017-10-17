using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace FuelSDK.MobilePush
{
    /// <summary>
    /// MobilePushLocation class represents the mobile push location object
    /// </summary>
    public class MobilePushLocation : MobilePushBase
    {
        /// <summary>
        /// Get or Set Name of the location.
        /// </summary>
        /// <value>Name of the location</value>
        public string Name { get; set; }
        /// <summary>
        /// Get or Set the text defining the location; usually a physical or mailing address.
        /// </summary>
        /// <value>Text defining the location</value>
        public string Location { get; set; }
        /// <summary>
        /// Get or Set the description or notes for the location.
        /// </summary>
        /// <value>Description or notes for the location</value>
        public string Description { get; set; }
        /// <summary>
        /// Get or Set the Unique identifier used to distinguish one beacon from another. Required if creating a beacon location. This number is found on the beacon hardware.
        /// </summary>
        /// <value>Unique identifier (if creating a beacon location) for the location</value>
        public string ProximityUuid { get; set; }
        /// <summary>
        /// Get or Set the radius of the location circle in meters.
        /// </summary>
        /// <value>Radius of the location</value>
        public int Radius { get; set; }
        /// <summary>
        /// Get or Set the location type, whether this is a geofence or beacon location. If not specified, it defaults to geofence.
        /// Geofence = 1,
        /// Beacon = 3
        /// </summary>
        /// <value>type of the location</value>
        public PushMessageLocationType LocationType { get; set; }
        /// <summary>
        /// Get or Set the value a particular beacon within a group. Required if creating a beacon location. This number is found on the beacon hardware.
        /// </summary>
        /// <value>Specifies a particular beacon within a group</value>
        public int Major { get; set; }
        /// <summary>
        /// Get or Set the groups a related set of beacons. Required if creating a beacon location. This number is found on the beacon hardware.
        /// </summary>
        /// <value>Radius of the location</value>
        public int Minor { get; set; }
        /// <summary>
        /// Get or Set the center point of the location circle.
        /// </summary>
        /// <value>Center point of the location</value>
        public LocationCenter Center { get; set; }
        /// <summary>
        /// Get or Set the array of attributes for the location
        /// </summary>
        /// <value>Attributes for the location</value>
        public LocationAttribute[] Attributes { get; set; }
        /// <summary>
        /// Get or Set the location ID of the location.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string LocationId { get; set; }

        /// <summary>
        /// Default constructor. Initialize the default endpoint, URLProperties and requried URL properties.
        /// </summary>
        public MobilePushLocation()
        {
            Endpoint = "https://www.exacttargetapis.com/push/v1/location";
            URLProperties = new string[0];
            RequiredURLProperties = new string[0];
            Radius = 0;
        }

        /// <summary>
        /// Creates a new location.
        /// </summary>
        /// <returns>Newly created MobilePushLocation object.</returns>
        public MobilePushLocation CreateLocation()
        {
            if (Name == null || Name.Length == 0)
            {
                throw new ApplicationException("Name is either null or empty. Need to specify Name.");
            }
            return MobilePushReturn.CreateLocation(this);
        }

        /// <summary>
        /// Deletes an existing location.
        /// </summary>
        /// <returns>retruns true if successfull, false or exception otherwise.</returns>
        public bool DeleteLocation()
        {
            if (LocationId == null || LocationId.Length == 0)
            {
                throw new ApplicationException("LocationId is either null or empty. Need to specify LocationId.");
            }
            Endpoint = "https://www.exacttargetapis.com/push/v1/location/{LocationId}";
            URLProperties = new[] { "LocationId" };
            RequiredURLProperties = new[] { "LocationId" };
            return MobilePushReturn.DeleteLocation(this);
        }

        /// <summary>
        /// Updates an existing location.
        /// </summary>
        /// <returns>retruns true if successfull, false or exception otherwise.</returns>
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
            if (Radius == 0)
            {
                throw new ApplicationException("Radius is required and it can not be zero.");
            }
            if (Center == null)
            {
                throw new ApplicationException("Center is required.");
            }
            Endpoint = "https://www.exacttargetapis.com/push/v1/location/{LocationId}";
            URLProperties = new[] { "LocationId" };
            RequiredURLProperties = new[] { "LocationId" };
            return MobilePushReturn.UpdateLocation(this);
        }

        /// <summary>
        /// Gets a specific location by LocationId.
        /// </summary>
        /// <returns>MobilePushLocation object associated with the LocationId.</returns>
        public MobilePushLocation GetLocation()
        {
            if (LocationId == null || LocationId.Length == 0)
            {
                throw new ApplicationException("LocationId is either null or empty. Need to specify LocationId.");
            }
            Endpoint = "https://www.exacttargetapis.com/push/v1/location/{LocationId}";
            URLProperties = new[] { "LocationId" };
            RequiredURLProperties = new[] { "LocationId" };
            return MobilePushReturn.GetLocation(this);
        }

        /// <summary>
        /// Gets an array of all locations.
        /// </summary>
        /// <returns>array of MobilePushLocation objects.</returns>
        public MobilePushLocation[] GetLocations()
        {
            return MobilePushReturn.GetLocations(this.AuthStub);
        }

    }
}
