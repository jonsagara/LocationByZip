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

        public IEnumerable<LocationInRadius> GetLocationsInRadius(string zipCode, double radius)
        {
            ValidateRadiusArgument(radius);

            var locationsNearby = new List<LocationInRadius>();
            Location origin = GetByZipCode(zipCode);

            if (origin != null)
            {
                RadiusBox bounds = RadiusBox.Create(origin, radius);

                locationsNearby.AddRange(_locationRepository.GetLocationsInRadius(origin, bounds));
            }

            return locationsNearby;
        }

        public double GetDistanceBetweenLocations(string zipCode1, string zipCode2)
        {
            ValidateZipCodeArgument(zipCode1);
            ValidateZipCodeArgument(zipCode2);

            double distance = 0.0;
            Location location1 = GetByZipCode(zipCode1);
            Location location2 = GetByZipCode(zipCode2);

            if (location1 != null && location2 != null)
            {
                distance = location1.DistanceFrom(location2);
            }

            return distance;
        }


        //
        // Helpers
        //

        private void ValidateZipCodeArgument(string zipCode)
        {
            if (string.IsNullOrWhiteSpace(zipCode))
            {
                throw new ArgumentException("ZIP Code must be non-null, non-white space string", "zipCode");
            }
        }

        private void ValidateCityArgument(string city)
        {
            if (string.IsNullOrWhiteSpace(city))
            {
                throw new ArgumentException("City must be non-null, non-white space string", "city");
            }
        }

        private void ValidateStateArgument(string state)
        {
            if (string.IsNullOrWhiteSpace(state))
            {
                throw new ArgumentException("State must be non-null, non-white space string", "state");
            }
        }

        private void ValidateRadiusArgument(double radius)
        {
            if (radius <= 0.0)
            {
                throw new ArgumentOutOfRangeException("radius", radius, "Radius must be greater than 0");
            }
        }
    }
}
