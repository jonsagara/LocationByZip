using System;
using System.Diagnostics.CodeAnalysis;

namespace LocationByZip
{
    /// <summary>
    /// A RadiusBox encloses a &quot;box&quot; area around a location, where each side of the square is
    ///  radius miles away from the location.  Doing it this way includes ~22% more area than if we
    ///  used a proper circle, but using a box greatly simplifies the SQL query.
    /// </summary>
    public class RadiusBox
    {
        /// <summary>
        /// Represents the Northern latitude line.
        /// </summary>
        public double TopLatitude { get; }

        /// <summary>
        /// Represents the Southern latitude line.
        /// </summary>
        public double BottomLatitude { get; }

        /// <summary>
        /// Represents the Western longitude line.
        /// </summary>
        public double LeftLongitude { get; }

        /// <summary>
        /// Represents the Eastern longitude line.
        /// </summary>
        public double RightLongitude { get; }


        /// <summary>
        /// Represents the radius of the search area.
        /// </summary>
        public double RadiusMiles { get; }



        private RadiusBox(double topLat, double bottomLat, double leftLon, double rightLon, double radiusMiles)
        {
            TopLatitude = topLat;
            BottomLatitude = bottomLat;
            LeftLongitude = leftLon;
            RightLongitude = rightLon;

            RadiusMiles = radiusMiles;
        }


        /// <summary>
        /// <para>Creates a box that encloses the specified <paramref name="location"/>, where the sides of the
        /// square are <paramref name="radiusMiles"/> miles away from the <paramref name="location"/> at the 
        /// perpendicular.</para>
        /// <para>NOTE: we do not actually generate lat/lon pairs; we only generate the coordinates that 
        /// represent each side of the box.</para>
        /// <para>Formula obtained from Dr. Math at http://www.mathforum.org/library/drmath/view/51816.html.</para>
        /// </summary>
        /// <param name="location">The center of the search radius, and therefore of the bounding box.</param>
        /// <param name="radiusMiles">The search radius in miles.</param>
        public static RadiusBox Create([AllowNull] Location location, double radiusMiles)
        {
            if (location is null)
            {
                throw new ArgumentNullException(nameof(location));
            }

            /*
                A point {lat,lon} is a distance d out on the tc radial from point 1 if:
			
                lat = asin (sin (lat1) * cos (d) + cos (lat1) * sin (d) * cos (tc))
                dlon = atan2 (sin (tc) * sin (d) * cos (lat1), cos (d) - sin (lat1) * sin (lat))
                lon = mod (lon1 + dlon + pi, 2 * pi) - pi
			
                Where:
                    * d is the distance in radians (an arc), so the desired radius divided by
                        the radius of the Earth.
                    * tc = 0 is N, tc = pi is S, tc = pi/2 is E, tc = 3*pi/2 is W.
            */

            double latitudeRadians = location.Latitude.ToRadians();
            double longitudeRadians = location.Longitude.ToRadians();
            double radiusRadians = radiusMiles / Globals.EarthRadiusMiles;

            //	N (tc == 0):
            //		lat = asin (sin(lat1)*cos(d) + cos(lat1)*sin(d))
            //			= asin (sin(lat1 + d))
            //			= lat1 + d
            //	Unused:
            //		lon	= lon1, because north-south lines follow lines of longitude.
            var topLatRadians = latitudeRadians + radiusRadians;

            //	S (tc == pi):
            //		lat = asin (sin(lat1)*cos(d) - cos(lat1)*sin(d))
            //			= asin (sin(lat1 - d))
            //			= lat1 - d
            //	Unused:
            //		lon	= lon1, because north-south lines follow lines of longitude.
            var bottomLatRadians = latitudeRadians - radiusRadians;

            //	E (tc == pi/2):
            //		lat	 = asin (sin(lat1)*cos(d))
            //		dlon = atan2 (sin(tc)*sin(d)*cos(lat1), cos(d) - sin(lat1)*sin(lat))
            //		lon	 = mod (lon1 + dlon + pi, 2*pi) - pi
            var lat = Math.Asin(Math.Sin(latitudeRadians) * Math.Cos(radiusRadians));
            var dlonE = Math.Atan2(Math.Sin(Math.PI / 2.0) * Math.Sin(radiusRadians) * Math.Cos(latitudeRadians), Math.Cos(radiusRadians) - Math.Sin(latitudeRadians) * Math.Sin(lat));
            var rightLonRadians = ((longitudeRadians + dlonE + Math.PI) % (2.0 * Math.PI)) - Math.PI;

            //	W (tc == 3*pi/2):
            //		lat	 = asin (sin(lat1)*cos(d))
            //		dlon = atan2 (sin(tc)*sin(d)*cos(lat1), cos(d) - sin(lat1)*sin(lat))
            //		lon	 = mod (lon1 + dlon + pi, 2*pi) - pi
            var dlonW = Math.Atan2(Math.Sin(3.0 * Math.PI / 2.0) * Math.Sin(radiusRadians) * Math.Cos(latitudeRadians), Math.Cos(radiusRadians) - Math.Sin(latitudeRadians) * Math.Sin(lat));
            var leftLonRadians = ((longitudeRadians + dlonW + Math.PI) % (2.0 * Math.PI)) - Math.PI;


            return new RadiusBox(
                topLat: topLatRadians.ToDegrees(),
                bottomLat: bottomLatRadians.ToDegrees(),
                leftLon: leftLonRadians.ToDegrees(),
                rightLon: rightLonRadians.ToDegrees(),
                radiusMiles: radiusMiles
                );
        }
    }
}
