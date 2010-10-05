using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace SagaraSoftware.ZipCodeUtil
{
	/// <summary>
	/// Summary description for Radius.
	/// </summary>
	public class Radius
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="inLocation">The Location around which to search.</param>
		/// <param name="inRadius">Search radius in miles.</param>
		/// <returns></returns>
		public static IList<LocationInRadius> LocationsWithinRadius(Location inLocation, double inRadius)
		{
			Debug.Assert(null != inLocation);
			Debug.Assert(inRadius > 0.0);

			if (null == inLocation)
				throw new ArgumentNullException("inLocation", "Null location passed in.");
			if (inRadius <= 0.0)
				throw new ArgumentOutOfRangeException("inRadius", inRadius, "Invalid value for radius passed in.");

			Debug.Assert(double.MinValue != inLocation.Latitude);
			Debug.Assert(double.MinValue != inLocation.Longitude);

			if (double.MinValue == inLocation.Latitude)
				throw new ArgumentException("inLocation.Latitude", string.Format("The database does not contain latitude information for {0}, {1}.", inLocation.City, inLocation.State));
			if (double.MinValue == inLocation.Longitude)
				throw new ArgumentException("inLocation.Longitude", string.Format("The database does not contain longitude information for {0}, {1}.", inLocation.City, inLocation.State));


			RadiusBox radBox = RadiusBox.Create(inLocation, inRadius);

			return DataProvider
				.GetDataProvider()
				.GetLocationsWithinRadius(inLocation, radBox);
		}
	}

	/// <summary>
	/// A RadiusBox encloses a "box" area around a location, where each side of the square is
	///  radius miles away from the location.  Doing it this way includes ~22% more area than if we
	///  used a proper circle, but using a box simplifies the SQL query.
	/// </summary>
	public class RadiusBox
	{
		/// <summary>
		/// Represents the Southern latitude line.
		/// </summary>
		public double BottomLine { get; set; }


		/// <summary>
		/// Represents the Northern latitude line.
		/// </summary>
		public double TopLine { get; set; }


		/// <summary>
		/// Represents the Western longitude line.
		/// </summary>
		public double LeftLine { get; set; }


		/// <summary>
		/// Represents the Eastern longitude line.
		/// </summary>
		public double RightLine { get; set; }


		/// <summary>
		/// Represents the radius of the search area.
		/// </summary>
		public double Radius { get; set; }


		/// <summary>
		/// Creates a box that encloses the specified location, where the sides of the square
		///  are inRadius miles away from the location at the perpendicular.  Note that we do
		///  not actually generate lat/lon pairs; we only generate the coordinate that 
		///  represents the side of the box.
		/// </summary>
		/// <remarks>
		/// <para>Formula obtained from Dr. Math at http://www.mathforum.org/library/drmath/view/51816.html.</para>
		/// </remarks>
		/// <param name="inLocation"></param>
		/// <param name="inRadius"></param>
		/// <returns></returns>
		public static RadiusBox Create(Location inLocation, double inRadius)
		{
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
			double lat;
			double dlon;
			double dLatInRads = inLocation.Latitude * (Math.PI / 180.0);
			double dLongInRads = inLocation.Longitude * (Math.PI / 180.0);
			double dDistInRad = inRadius / Globals.EarthRadiusMiles;
			RadiusBox box = new RadiusBox();
			box.Radius = inRadius;

			//	N (tc == 0):
			//		lat = asin (sin(lat1)*cos(d) + cos(lat1)*sin(d))
			//			= asin (sin(lat1 + d))
			//			= lat1 + d
			//	Unused:
			//		lon	= lon1, because north-south lines follow lines of longitude.
			box.TopLine = dLatInRads + dDistInRad;
			box.TopLine *= (180.0 / Math.PI);

			//	S (tc == pi):
			//		lat = asin (sin(lat1)*cos(d) - cos(lat1)*sin(d))
			//			= asin (sin(lat1 - d))
			//			= lat1 - d
			//	Unused:
			//		lon	= lon1, because north-south lines follow lines of longitude.
			box.BottomLine = dLatInRads - dDistInRad;
			box.BottomLine *= (180.0 / Math.PI);

			//	E (tc == pi/2):
			//		lat	 = asin (sin(lat1)*cos(d))
			//		dlon = atan2 (sin(tc)*sin(d)*cos(lat1), cos(d) - sin(lat1)*sin(lat))
			//		lon	 = mod (lon1 + dlon + pi, 2*pi) - pi
			lat = Math.Asin(Math.Sin(dLatInRads) * Math.Cos(dDistInRad));
			dlon = Math.Atan2(Math.Sin(Math.PI / 2.0) * Math.Sin(dDistInRad) * Math.Cos(dLatInRads), Math.Cos(dDistInRad) - Math.Sin(dLatInRads) * Math.Sin(lat));
			box.RightLine = ((dLongInRads + dlon + Math.PI) % (2.0 * Math.PI)) - Math.PI;
			box.RightLine *= (180.0 / Math.PI);

			//	W (tc == 3*pi/2):
			//		lat	 = asin (sin(lat1)*cos(d))
			//		dlon = atan2 (sin(tc)*sin(d)*cos(lat1), cos(d) - sin(lat1)*sin(lat))
			//		lon	 = mod (lon1 + dlon + pi, 2*pi) - pi
			dlon = Math.Atan2(Math.Sin(3.0 * Math.PI / 2.0) * Math.Sin(dDistInRad) * Math.Cos(dLatInRads), Math.Cos(dDistInRad) - Math.Sin(dLatInRads) * Math.Sin(lat));
			box.LeftLine = ((dLongInRads + dlon + Math.PI) % (2.0 * Math.PI)) - Math.PI;
			box.LeftLine *= (180.0 / Math.PI);

			return box;
		}
	}
}
