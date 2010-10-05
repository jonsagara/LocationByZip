using System;
using System.Diagnostics;

namespace SagaraSoftware.ZipCodeUtil
{
	/// <summary>
	/// The Distance class takes two <see cref="SagaraSoftware.ZipCodeUtil.Location" /> objects and
	///  uses their Latitude and Longitude to determine the distance between them.  Uses the
	///  Haversine formula.
	/// </summary>
	public static class Distance
	{
		/// <summary>
		/// Returns the distance in miles between two locations, calculated using the Haversine
		///  forumula.
		/// </summary>
		/// <param name="inLoc1"></param>
		/// <param name="inLoc2"></param>
		/// <returns></returns>
		public static double GetDistance(Location inLoc1, Location inLoc2)
		{
			Debug.Assert(inLoc1 != null);
			Debug.Assert(inLoc2 != null);

			if (inLoc1 == null)
				throw new ArgumentNullException("inLoc1", "Null location passed in.");
			if (inLoc2 == null)
				throw new ArgumentNullException("inLoc2", "Null location passed in.");

			Debug.Assert(inLoc1.Latitude != double.MinValue);
			Debug.Assert(inLoc1.Longitude != double.MinValue);
			Debug.Assert(inLoc2.Latitude != double.MinValue);
			Debug.Assert(inLoc2.Longitude != double.MinValue);

			if (inLoc1.Latitude == double.MinValue)
				throw new ArgumentException("inLoc1.Latitude", string.Format("The database does not contain latitude information for {0}, {1}.", inLoc1.City, inLoc1.State));
			if (inLoc1.Longitude == double.MinValue)
				throw new ArgumentException("inLoc1.Longitude", string.Format("The database does not contain longitude information for {0}, {1}.", inLoc1.City, inLoc1.State));
			if (inLoc2.Latitude == double.MinValue)
				throw new ArgumentException("inLoc2.Latitude", string.Format("The database does not contain latitude information for {0}, {1}.", inLoc2.City, inLoc2.State));
			if (inLoc2.Longitude == double.MinValue)
				throw new ArgumentException("inLoc2.Longitude", string.Format("The database does not contain longitude information for {0}, {1}.", inLoc2.City, inLoc2.State));

			return Haversine(inLoc1, inLoc2);
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="inLoc1"></param>
		/// <param name="inLoc2"></param>
		/// <returns></returns>
		private static double Haversine(Location inLoc1, Location inLoc2)
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
			double dLat1InRad = inLoc1.Latitude * (Math.PI / 180.0);
			double dLong1InRad = inLoc1.Longitude * (Math.PI / 180.0);
			double dLat2InRad = inLoc2.Latitude * (Math.PI / 180.0);
			double dLong2InRad = inLoc2.Longitude * (Math.PI / 180.0);

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
