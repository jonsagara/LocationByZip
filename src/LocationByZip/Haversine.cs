using System;

namespace LocationByZip
{
    internal static class Haversine
    {
        /// <summary>
        /// Calculates the great-circle distance between two points on a sphere from their 
        /// longitudes and latitudes.
        /// </summary>
        /// <remarks>See: http://en.wikipedia.org/wiki/Haversine_formula</remarks>
        /// <param name="loc1"></param>
        /// <param name="loc2"></param>
        /// <returns></returns>
        public static double CalculateDistance(Location loc1, Location loc2)
        {
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
            double dDistance = double.MinValue;
            double dLat1InRad = loc1.Latitude * (Math.PI / 180.0);
            double dLong1InRad = loc1.Longitude * (Math.PI / 180.0);
            double dLat2InRad = loc2.Latitude * (Math.PI / 180.0);
            double dLong2InRad = loc2.Longitude * (Math.PI / 180.0);

            double dLongitude = dLong2InRad - dLong1InRad;
            double dLatitude = dLat2InRad - dLat1InRad;

            // Intermediate result a.
            double a = Math.Pow(Math.Sin(dLatitude / 2.0), 2.0) + Math.Cos(dLat1InRad) * Math.Cos(dLat2InRad) * Math.Pow(Math.Sin(dLongitude / 2.0), 2.0);

            // Intermediate result c (great circle distance in Radians).
            double c = 2.0 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1.0 - a));

            // Distance.
            dDistance = Globals.EarthRadiusMiles * c;

            return dDistance;
        }
    }
}
