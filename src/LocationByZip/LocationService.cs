using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace LocationByZip
{
    public class LocationService
    {
        private readonly ILocationRepository _locationRepository;

        public LocationService(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }


        //
        // LocationService Methods
        //

        public async Task<Location?> GetByZipCodeAsync([AllowNull] string zipCode)
        {
            ValidateZipCodeArgument(zipCode);

            return await _locationRepository.GetByZipCodeAsync(zipCode);
        }

        public async Task<IReadOnlyCollection<Location>> GetByCityStateAsync([AllowNull] string city, [AllowNull] string state)
        {
            ValidateCityArgument(city);
            ValidateStateArgument(state);

            return await _locationRepository.GetByCityStateAsync(city, state);
        }

        public async Task<IReadOnlyCollection<LocationInRadius>> GetLocationsInRadiusAsync(string zipCode, double radiusMiles)
        {
            ValidateZipCodeArgument(zipCode);
            ValidateRadiusArgument(radiusMiles);

            var locationsNearby = new List<LocationInRadius>();

            // Get the lat/lon coordinates of the ZIP code (usually the centroid).
            var centerOfSearch = await GetByZipCodeAsync(zipCode);

            if (centerOfSearch is object)
            {
                // Create a bounding box of radius miles around the center of the search.
                var boundingBox = RadiusBox.Create(centerOfSearch, radiusMiles);

                // Get all locations within the bounding box, and then filter out any that are more than 
                //   radius miles away from the center of the search.
                locationsNearby.AddRange(await _locationRepository.GetLocationsInRadiusAsync(centerOfSearch, boundingBox));
            }

            return locationsNearby;
        }

        public async Task<double> GetDistanceBetweenLocationsAsync(string zipCode1, string zipCode2)
        {
            ValidateZipCodeArgument(zipCode1);
            ValidateZipCodeArgument(zipCode2);

            var location1 = await GetByZipCodeAsync(zipCode1);
            var location2 = await GetByZipCodeAsync(zipCode2);

            return location1 is object && location2 is object
                ? location1.DistanceFrom(location2)
                : 0.0;
        }


        //
        // Helpers
        //

        private void ValidateZipCodeArgument([AllowNull] string zipCode)
        {
            if (string.IsNullOrWhiteSpace(zipCode))
            {
                throw new ArgumentException("ZIP Code must be non-null, non-white space string", nameof(zipCode));
            }
        }

        private void ValidateCityArgument([AllowNull] string city)
        {
            if (string.IsNullOrWhiteSpace(city))
            {
                throw new ArgumentException("City must be non-null, non-white space string", nameof(city));
            }
        }

        private void ValidateStateArgument([AllowNull] string state)
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
