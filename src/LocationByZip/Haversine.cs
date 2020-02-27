using System;
using System.Diagnostics.CodeAnalysis;

namespace LocationByZip
{
    internal static class Haversine
    {
        /// <summary>
        /// Calculates the great-circle distance in miles between two points on a sphere from their 
        /// longitudes and latitudes.
        /// </summary>
        /// <remarks>See: http://en.wikipedia.org/wiki/Haversine_formula</remarks>
        /// <param name="location1">The first location.</param>
        /// <param name="location2">The second location.</param>
        public static double CalculateDistance([AllowNull] Location location1, [AllowNull] Location location2)
        {
            if (location1 is null)
            {
                throw new ArgumentNullException(nameof(location1));
            }

            if (location2 is null)
            {
                throw new ArgumentNullException(nameof(location2));
            }

            /*
                The Haversine formula according to Dr. Math.
                http://mathforum.org/library/drmath/view/51879.html
				
                dlon = lon2 - lon1
                dlat = lat2 - lat1
                a = (sin(dlat/2))^2 + cos(lat1) * cos(lat2) * (sin(dlon/2))^2
                c = 2 * atan2(sqrt(a), sqrt(1-a)) 
                d = R * c
				
                Where
                    * dlon is the change in longitude
                    * dlat is the change in latitude
                    * c is the great circle distance in Radians.
                    * R is the radius of a spherical Earth.
                    * The locations of the two points in spherical coordinates (longitude and 
                        latitude) are lon1,lat1 and lon2, lat2.
            */
            double latitude1Radians = location1.Latitude.ToRadians();
            double longitude1Radians = location1.Longitude.ToRadians();
            double latitude2Radians = location2.Latitude.ToRadians();
            double longitude2Radians = location2.Longitude.ToRadians();

            double dLongitude = longitude2Radians - longitude1Radians;
            double dLatitude = latitude2Radians - latitude1Radians;

            // Intermediate result a.
            double a = Math.Pow(Math.Sin(dLatitude / 2.0), 2.0) + Math.Cos(latitude1Radians) * Math.Cos(latitude2Radians) * Math.Pow(Math.Sin(dLongitude / 2.0), 2.0);

            // Intermediate result c (great circle distance in radians).
            double c = 2.0 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1.0 - a));

            // Distance.
            return Globals.EarthRadiusMiles * c;
        }
    }
}
