using System;
using System.Collections.Generic;

namespace LocationByZip
{
    public class LocationService
    {
        //
        // Instance Data
        //

        private ILocationRepository _locationRepository;


        //
        // Instance Constructors
        //

        public LocationService()
            : this(new SqlLocationRepository())
        {
        }

        public LocationService(ILocationRepository locationRepository)
        {
            this._locationRepository = locationRepository;
        }


        //
        // LocationService Methods
        //

        public Location GetByZipCode(string zipCode)
        {
            ValidateZipCodeArgument(zipCode);

            return _locationRepository.GetByZipCode(zipCode);
        }

        public IEnumerable<Location> GetByCityState(string city, string state)
        {
            ValidateCityArgument(city);
            ValidateStateArgument(state);

            return _locationRepository.GetByCityState(city, state);
        }

        public IEnumerable<LocationInRadius> GetLocationsInRadius(string zipCode, double radiusMiles)
        {
            ValidateZipCodeArgument(zipCode);
            ValidateRadiusArgument(radiusMiles);

            var locationsNearby = new List<LocationInRadius>();

            // Get the lat/lon coordinates of the ZIP code (usually the centroid).
            var centerOfSearch = GetByZipCode(zipCode);

            if (centerOfSearch != null)
            {
                // Create a bounding box of radius miles around the center of the search.
                var boundingBox = RadiusBox.Create(centerOfSearch, radiusMiles);

                // Get all locations within the bounding box, and then filter out any that are more than 
                //   radius miles away from the center of the search.
                locationsNearby.AddRange(_locationRepository.GetLocationsInRadius(centerOfSearch, boundingBox));
            }

            return locationsNearby;
        }

        public double GetDistanceBetweenLocations(string zipCode1, string zipCode2)
        {
            ValidateZipCodeArgument(zipCode1);
            ValidateZipCodeArgument(zipCode2);

            var location1 = GetByZipCode(zipCode1);
            var location2 = GetByZipCode(zipCode2);

            return location1 != null && location2 != null
                ? location1.DistanceFrom(location2)
                : 0.0;
        }


        //
        // Helpers
        //

        private void ValidateZipCodeArgument(string zipCode)
        {
            if (string.IsNullOrWhiteSpace(zipCode))
            {
                throw new ArgumentException("ZIP Code must be non-null, non-white space string", nameof(zipCode));
            }
        }

        private void ValidateCityArgument(string city)
        {
            if (string.IsNullOrWhiteSpace(city))
            {
                throw new ArgumentException("City must be non-null, non-white space string", nameof(city));
            }
        }

        private void ValidateStateArgument(string state)
        {
            if (string.IsNullOrWhiteSpace(state))
            {
                throw new ArgumentException("State must be non-null, non-white space string", nameof(state));
            }
        }

        private void ValidateRadiusArgument(double radius)
        {
            if (radius <= 0.0)
            {
                throw new ArgumentOutOfRangeException(nameof(radius), radius, "Radius must be greater than 0");
            }
        }
    }
}
